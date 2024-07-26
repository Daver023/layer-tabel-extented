using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIS.Core.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class LayerTabelAttribute : Attribute
    {
        #region 构造参数

        public LayerTabelAttribute(string type)
        {
            this.Type = type;
            this.Width = "50";
        }
        public LayerTabelAttribute(string title, string width, string toolbar, string alian)
        {
            this.Title = title;
            this.Width = width;
            this.ToolBar = toolbar;
            this.Align = alian;
        }

        public LayerTabelAttribute(string title, string width)
        {
            this.Title = title;
            this.Width = width;
        }
        public LayerTabelAttribute(string title, string width, bool isshow)
        {
            this.Title = title;
            this.Width = width;
            this.IsShow = isshow;
        }
        public LayerTabelAttribute(string title, string width, bool isshow, string toolbar, string alian, string template)
        {
            this.Title = title;
            this.Width = width;
            this.IsShow = isshow;
            this.ToolBar = toolbar;
            this.Align = alian;
            this.Template = template;
        }
        public LayerTabelAttribute(string title, string width, bool isshow, string toolbar, string template)
        {
            this.Title = title;
            this.Width = width;
            this.IsShow = isshow;
            this.ToolBar = toolbar;
        }
        #endregion

        #region 字段

        public string? Title { get; }
        /// <summary>
        /// 
        /// </summary>
        public string? Width { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsShow { get; }

        /// <summary>
        /// 工具模板ID
        /// </summary>
        public string? ToolBar { get; }

        /// <summary>
        /// 
        /// </summary>
        public string? Align { get; }

        /// <summary>
        /// 方法名和模板的ID
        /// </summary>
        public string? Template { get; }

        public string Type { get; set; }
        #endregion
    }
}
