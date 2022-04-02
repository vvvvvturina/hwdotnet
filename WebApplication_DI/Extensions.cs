using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApplicationMVC
{
    public static class Extensions
    {
        public static IHtmlContent MyEditorModel(this IHtmlHelper htmlHelper)
        {
            return new MyEditorForModels(htmlHelper.ViewData.Model! ?? htmlHelper.ViewData.ModelMetadata.ModelType
                .GetConstructor(Array.Empty<Type>())
                ?.Invoke(Array.Empty<object>()));
        }
    }
    public class MyEditorForModels : IHtmlContent
    {
        private Type _type;
        private readonly List<IHtmlContent> _list = new ();
        
        public MyEditorForModels(object model)
        {
            _type = model.GetType();
            CreateForms(model);
        }
        private void CreateForms(object model)
        {
            foreach (var property in _type.GetProperties())
            {
                _list.Add(CreateLabel(property));
                _list.Add(CreateDivForInput(property,model));
                _list.Add(CreateSpan(property,model));
            }
        }

        private static IHtmlContent CreateSpan(PropertyInfo propertyInfo, object model)
        {
            var span = new TagBuilder("span");
            var attribute = propertyInfo.GetCustomAttributes<ValidationAttribute>();
            foreach (var attributes in attribute)
            {
                if (!attributes.IsValid(propertyInfo.GetValue(model))) continue;
                span.MergeAttribute("class","validator-error");
                span.MergeAttribute("data-for",propertyInfo.Name);
                span.MergeAttribute("data-replace","true");
                return span.InnerHtml.Append(
                    attributes.ErrorMessage ?? attributes.FormatErrorMessage(propertyInfo.Name));
            }
            return span;
        }
        private static IHtmlContent CreateLabel(PropertyInfo propertyInfo)
        {
            var label = new TagBuilder("label");
            label.MergeAttribute("for", propertyInfo.Name);
            label.InnerHtml.AppendHtml(DisplayName(propertyInfo));
            return label;
        }
        private static IHtmlContent CreateDivForInput(PropertyInfo propertyInfo, object model)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("card-body");
            div.MergeAttribute("style", "width: 18rem;");
            div.InnerHtml.AppendHtml(propertyInfo.PropertyType.IsEnum
                ? CreateEnum(propertyInfo, model)
                : CreateInput(propertyInfo, model));
            return div;
        }

        private static IHtmlContent CreateEnum(PropertyInfo fieldInfo, object model)
        {
            var select = new TagBuilder("select");
            select.MergeAttribute("id", fieldInfo.Name);
            select.MergeAttribute("name", fieldInfo.Name);
            var variable = fieldInfo.PropertyType.GetFields();
            foreach (var items in variable)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", fieldInfo.Name);
                option.InnerHtml.AppendHtml(DisplayName(items));
                select.InnerHtml.AppendHtml(option);
            }
            return select;
        }
        private static string DisplayName(MemberInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<DisplayAttribute>()?.Name ?? ToCamelCase(propertyInfo.Name);
        }

        private static string ToCamelCase(string str)
        {
            return string.IsNullOrEmpty(str) || str.Length < 2
                ? str
                : char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
        private static IHtmlContent CreateInput(PropertyInfo propertyInfo, object model)
        {
            var input = new TagBuilder("input");
            input.MergeAttribute("class", "form-control");
            input.MergeAttribute("id", propertyInfo.Name);
            input.MergeAttribute("name", propertyInfo.Name);
            input.MergeAttribute("type", propertyInfo.Name);
            input.MergeAttribute("value",propertyInfo.GetValue(model)?.ToString());
            return input;
        }
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            foreach (var content in _list)
            {
                content.WriteTo(writer,encoder);
            }
        }
    }
}