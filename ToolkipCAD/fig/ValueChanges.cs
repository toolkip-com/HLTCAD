using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolkipCAD.fig
{
    class ValueChanges
    {
        private object myValue;
        public object MyValue
        {
            get { return myValue; }
            set
            {
                if (value != myValue)
                {
                    WhenMyValueChange();
                }
                myValue = value;
            }
        }
        //定义的委托
        public delegate void MyValueChanged(object sender, EventArgs e);
        //与委托相关联的事件
        public event MyValueChanged OnMyValueChanged;
        //事件触发函数
        private void WhenMyValueChange()
        {
            if (OnMyValueChanged != null)
            {
                OnMyValueChanged(this, null);

            }
        }

    }

}
