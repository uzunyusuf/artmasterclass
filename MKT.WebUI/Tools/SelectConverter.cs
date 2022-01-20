using Microsoft.AspNetCore.Mvc.Rendering;
using MKT.DataAccess.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MKT.WebUI.Tools
{
    public class SelectConverter
    {
        public static List<SelectListItem> CreateSelectList<T>(IList<T> list, Func<T, object> funcToGetValue,
    params Func<T, object>[] funcToGetTexts)
        {
            return list.Select(x => new SelectListItem()
            {
                Value = funcToGetValue(x).ToString(),
                Text = string.Join(" - ", (from f in funcToGetTexts select f(x)).ToList())
            }).ToList();
        }


        public static dynamic CreateSelectListForSelect2<T>(IList<T> list,
            Func<T, object> funcToGetValue, params Func<T, object>[] funcToGetTexts)
        {
            return list.Select(x => new
            {
                id = funcToGetValue(x).ToString(),
                text = string.Join(" - ", (from f in funcToGetTexts select f(x)).ToList())
            }).ToList();
        }

        public static dynamic CreateSelectListForSelect2WithHelper<T>(IList<T> list, Func<T, object> funcToGetValue,
            Func<T, object> funcToGetText, Func<T, object> funcToHelpText)
        {
            return list.Select(x => new
            {
                id = funcToGetValue(x).ToString(),
                text = funcToGetText(x).ToString(),
                helpText = funcToHelpText(x).ToString()
            }).ToList();
        }

        public static List<SelectListItem> StringToSelectList(List<string> stringList)
        {
            return (from s in stringList
                    select new SelectListItem()
                    {
                        Value = s,
                        Text = s
                    }).ToList();
        }

        public static List<SelectListItem> RoleParameters()
        {
            var roller = typeof(ROLE).GetFields(BindingFlags.Static | BindingFlags.Public)
                .ToList();
            return (from rol in roller
                    select new SelectListItem { Value = rol.GetValue(null).ToString(), Text = rol.GetValue(null).ToString() }).ToList();
        }
    }
}
