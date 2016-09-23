using System.Net;
using QQLib.Http;
using System.Collections.Generic;
using System;
using GDXJ.Lib.Object.User;
using GDXJ.Lib.Object.Login;
using GDXJ.Lib.Object;
using GDXJ.Lib.Object.setting;

namespace GDXJ.Lib.Lib
{
    public class Gdxj
    {
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

        public Gdxj()
        {
            try
            {
                Photo.InitPath();
                myCookie = new MyCookie();
                gdxjUser = new GdxjUser();
                login = new Login_Gdxj(gdxjUser, myCookie);
            }
            catch
            {
                flag = -1;
            }           
        }

        public List<Grade> QueryGrade()
        {
            return Grade.QueryGradeBySchool(ref myCookie.cookie, gdxjUser.organ.organCode);
        }

        public List<Classes> QueryClasses(string gradeId)
        {
            return Classes.QueryClassesByGrade(ref myCookie.cookie, gradeId);
        }

        public List<Student> QueryStudent(string classId, int start = 0, int limit = 0)
        {
            return Student.QueryStudent(ref myCookie.cookie, gdxjUser.organ.organCode, classId, start, limit);
        }

        public List<Student> QueryStudentById(string studentId)
        {
            return Student.QueryStudent(ref myCookie.cookie, gdxjUser.organ.organCode, "", studentId);
        }

        public void SaveStudent(Student student)
        {
            student.SaveStudent(ref myCookie.cookie);
        }

        public void GetDictionarys()
        {
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
