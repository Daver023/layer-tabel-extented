using Furion;
using Furion.Localization;
using IMIS.Core;
using IMIS.Core.Attributes;
using IMIS.Core.Model;
using IMIS.Entry;
using IMIS.Jobs;
using IMIS.Web.API.Models;
using IMIS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using NewLife;
using NPOI.POIFS.FileSystem;
using SqlSugar;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;

namespace IMIS.Web.API.Controllers
{
    /// <summary>
    /// 报表配置接口
    /// </summary>
    [Route("api/ReportSetting")]
    [ApiController]
    [AllowAnonymous]

    public class APIReportSettingController : ControllerBase
    {
        

        /// <summary>
        /// 获取表格的列
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLayerTableModels/{tableName}")]
        public List<LayerTableModel> GetLayerTableModels(string tableName)
        {
            var type = GetTypeByTableName(tableName);
            var cols = GetColumns(type);
            return cols;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private Type GetTypeByTableName(string tableName)
        {
            var entityAssemarr = LoadAllAssemblys();
            Type entityType = null;
            foreach (var asssears in entityAssemarr)
            {
                var types = asssears.GetTypes().Where(p => p.CustomAttributes.Any(c => c.AttributeType == typeof(SugarTable)));
                foreach (var type in types)
                {
                    if (type.Name.ToLower() == tableName.ToLower())
                    {
                        return type;
                    }
                }
            }
            return entityType;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<LayerTableModel> GetColumns(Type type)
        {
            if (type is null) return new List<LayerTableModel>();
            var cols = new List<LayerTableModel>();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(LayerTabelAttribute), true))
                {
                    foreach (LayerTabelAttribute item in prop.GetCustomAttributes(typeof(LayerTabelAttribute), true))//获取字段所有的特性
                    {
                        cols.Add(new LayerTableModel()
                        {
                            type = item.Type ?? "",
                            title = item.Title ?? prop.Name,
                            align = item.Align ?? "left",
                            width = item.Width ?? "200",
                            field = prop.Name,
                            toolbar = item.ToolBar ?? "",
                            hide = item.IsShow
                        });
                    }
                }
            }
            return cols;
        }

        public List<Assembly> LoadAllAssemblys()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            var libs = deps.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package" && lib.Name.StartsWith("IMIS"));
            foreach (var lib in libs)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                list.Add(assembly);
            }
            return list;
        }
    }
}
