
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SortByDemo
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// 数据
        /// </summary>
        public static List<TestData> dataList = new List<TestData>();
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void dataInit() {
            dataList = new List<TestData>();
            dataList.Add(new TestData
            {
                name = "张三",
                sex = "男",
                age = 30
            });
            dataList.Add(new TestData
            {
                name = "李四",
                sex = "男",
                age = 33
            });
            dataList.Add(new TestData
            {
                name = "王丽",
                sex = "女",
                age = 30
            });
            dataList.Add(new TestData
            {
                name = "赵奇",
                sex = "女",
                age = 35
            });
            dataList.Add(new TestData
            {
                name = "李东",
                sex = "男",
                age = 35
            });
            dataList.Add(new TestData
            {
                name = "李东",
                sex = "男",
                age = 50
            });

            string orderBy = keyBox.Text;
            if (!string.IsNullOrEmpty(orderBy))
            {
                dataList = dataList.SortBy(orderBy);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                dataInit();
                
            }

        }

        protected void bt_paixu_Click(object sender, EventArgs e)
        {
            string orderBy = keyBox.Text;
            if (string.IsNullOrEmpty(orderBy))
            {
                dataInit();
            }
            else {
                dataList = dataList.SortBy(orderBy);
            }
            
            dataUpdatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;
            //添加触发
            AsyncPostBackTrigger tri = new AsyncPostBackTrigger();
            tri.ControlID = "bt_paixu";
            tri.EventName = "Click";
            dataUpdatePanel.Triggers.Add(tri);


        }

        
    }
}