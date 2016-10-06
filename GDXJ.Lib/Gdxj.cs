using System.Net;
using QQLib.Http;
using System.Collections.Generic;
using System;
using GDXJ.Lib.Object.User;
using GDXJ.Lib.Object.Login;
using GDXJ.Lib.Object;
using GDXJ.Lib.Object.setting;

namespace GDXJ.Lib
{
    public class Gdxj
    {
        GDXJEvens GdxjEvens;
        int flag = 0;

        Login_Gdxj login;
        MyCookie myCookie;
        GdxjUser gdxjUser;

        public GdxjUser GdxjUser
        {
            get { return gdxjUser; }
        }

        public Login_Gdxj Login
        {
            get { return login; }
        }

        public MyCookie GdxjCookie
        {
            get
            {
                return myCookie;
            }
        }

        public void Subscribe(GDXJEvens.GDXJEventHandler handler)
        {
            if (GdxjEvens != null)
                GdxjEvens.Subscribe(handler);
        }
        //取消订阅事件
        public void UnSubscribe(GDXJEvens.GDXJEventHandler handler)
        {
            if (GdxjEvens != null)
                GdxjEvens.UnSubscribe(handler);
        }

        public void Initialization()
        {
            try
            {
                login.Initialization();
                flag = 0;
            }
            catch
            {
                flag = -1;
                GdxjEvens.RaiseEvent(-1, "初始化学籍系统信息失败！");
            }     
        }
        public Gdxj()
        {
            GdxjEvens = new GDXJEvens();

            Photo.InitPath();
            myCookie = new MyCookie();
            gdxjUser = new GdxjUser();
            login = new Login_Gdxj(gdxjUser, myCookie,GdxjEvens);

            flag = -1;
        }

        public void RegistrationIsCompleted()
        {

        }

        public List<Grade> QueryGrade()
        {
            if (flag!=0) throw(new Exception("学籍系统未进行初始化！"));
            return Grade.QueryGradeBySchool(ref myCookie.cookie, gdxjUser.organ.organCode);
        }

        public List<Classes> QueryClasses(string gradeId)
        {
            if (flag != 0) throw (new Exception("学籍系统未进行初始化！"));
            return Classes.QueryClassesByGrade(ref myCookie.cookie, gradeId);
        }

        public List<Student> QueryStudent(string classId, int start = 0, int limit = 0)
        {
            if (flag != 0) throw (new Exception("学籍系统未进行初始化！"));
            return Student.QueryStudent(ref myCookie.cookie, gdxjUser.organ.organCode, classId, start, limit);
        }

        public List<Student> QueryStudentById(string studentId)
        {
            if (flag != 0) throw (new Exception("学籍系统未进行初始化！"));
            return Student.QueryStudent(ref myCookie.cookie, gdxjUser.organ.organCode, "", studentId);
        }

        public void SaveStudent(Student student)
        {
            if (flag != 0) throw (new Exception("学籍系统未进行初始化！"));
            student.SaveStudent(ref myCookie.cookie);
        }

        public void GetDictionarys()
        {
            if (flag != 0) throw (new Exception("学籍系统未进行初始化！"));
            Dict.GetDictionarys(this);
        }

        ~Gdxj()
        {
            login.Logout();
        }
    }

    public class MyCookie
    {
        public CookieContainer cookie;

        public void Initialization()
        {
            cookie = new CookieContainer();
        }

        public MyCookie()
        {
            Initialization();
        }
    }
}
