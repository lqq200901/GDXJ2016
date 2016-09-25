using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDXJ.Lib
{
    public class GDXJEvens
    {
        //定义事件参数类
        public class GDXJEvenArgs : EventArgs
        {
            public readonly string MessageToRaiseEvent;
            public readonly int ResultToRaiseEvent;
            public GDXJEvenArgs(int result, string message)
            {
                ResultToRaiseEvent = result;
                MessageToRaiseEvent = message;
            }
        }

        //定义delegate
        public delegate void GDXJEventHandler(object sender, GDXJEvenArgs e);
        //用event 关键字声明事件对象
        public event GDXJEventHandler GDXJEvent;

        //事件触发方法
        protected virtual void OnGDXJEvent(GDXJEvenArgs e)
        {
            if (GDXJEvent != null)
                GDXJEvent(this, e);
        }

        //引发事件
        public void RaiseEvent(int result, string keyToRaiseEvent)
        {
            OnGDXJEvent(new GDXJEvenArgs(result, keyToRaiseEvent));
        }

        //订阅事件
        public void Subscribe(GDXJEventHandler handler)
        {
            GDXJEvent += new GDXJEventHandler(handler);
        }
        //取消订阅事件
        public void UnSubscribe(GDXJEventHandler handler)
        {
            GDXJEvent -= new GDXJEventHandler(handler);
        }
    }
}
