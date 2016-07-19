using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi
{
    public static class Extension
    {
        /// <summary>
        /// List Box for
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ListTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> models, IDictionary<string, object> htmlAttributes)
        {
            string controlName = ExpressionHelper.GetExpressionText(expression);
            string controlFullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(controlName);
            string controlId = TagBuilder.CreateSanitizedId(controlFullName);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string controlValue = (metadata.Model == null ? string.Empty : metadata.Model.ToString());

            TagBuilder tag = new TagBuilder("input");
            tag.Attributes.Add("name", controlFullName);
            tag.Attributes.Add("id", controlId);
            tag.Attributes.Add("type", "text");
            tag.Attributes.Add("class", "txtValueBox");
            tag.Attributes.Add("value", controlValue.ToString());
            tag.Attributes.Add("onclick", "applicationForm.listBox.show(this)");
            tag.Attributes.Add("onblur", "applicationForm.listBox.hide(this)");

            IDictionary<string, object> validationAttributes = helper.GetUnobtrusiveValidationAttributes(controlFullName, metadata);

            foreach (string key in validationAttributes.Keys)
            {
                tag.Attributes.Add(key, validationAttributes[key].ToString());
            }

            MvcHtmlString inputHtml = new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(string.Format("<div class='divListBox' >"));
            strBuilder.Append(inputHtml.ToHtmlString());
            strBuilder.Append(string.Format("<ul class='ulListBox' style='display:none' >"));
            foreach (var listItem in models)
            {
                strBuilder.Append(string.Format("<li value='{0}' onclick='applicationForm.listBox.onSelect(this)'>{1}</li>", listItem.Value, listItem.Text));
            }
            strBuilder.Append(string.Format("</ul>"));
            strBuilder.Append(string.Format("</div>"));
            var mvcStr = new MvcHtmlString(strBuilder.ToString());
            return mvcStr;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DropDownTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> models, IDictionary<string, object> htmlAttributes)
        {
            string controlName = ExpressionHelper.GetExpressionText(expression);
            string controlFullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(controlName);
            string controlId = TagBuilder.CreateSanitizedId(controlFullName);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string controlValue = (metadata.Model == null ? string.Empty : metadata.Model.ToString());

            TagBuilder tag = new TagBuilder("input");
            tag.Attributes.Add("name", controlFullName);
            tag.Attributes.Add("id", string.Format("hdn_{0}", controlId));
            tag.Attributes.Add("type", "hidden");
            tag.Attributes.Add("class", "hdnDDLBox");
            tag.Attributes.Add("value", controlValue.ToString());

            IDictionary<string, object> validationAttributes = helper.GetUnobtrusiveValidationAttributes(controlFullName, metadata);

            foreach (string key in validationAttributes.Keys)
            {
                tag.Attributes.Add(key, validationAttributes[key].ToString());
            }

            MvcHtmlString inputHtml = new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));

            StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Append(string.Format("<div class='dropdown' >"));
            //strBuilder.Append(inputHtml.ToHtmlString());
            //var ddlId = string.Format("ddl_{0}", controlId);
            //strBuilder.Append("<button class='btn btn-default dropdown-toggle' type='button' id='" + ddlId + "' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>");
            //strBuilder.Append("Select <span class='caret'></span></button>");
            //strBuilder.Append(string.Format("<ul class='dropdown-menu' aria-labelledby='dropdownMenu1'>"));
            //foreach (var listItem in models)
            //{
            //    strBuilder.Append(string.Format("<li><a href='#' value='{0}' onclick='applicationForm.listBox.onSelect(this)'> {1}</a></li>", listItem.Value, listItem.Text));
            //}
            //strBuilder.Append(string.Format("</ul>"));
            //strBuilder.Append(string.Format("</div>"));
            var mvcStr = new MvcHtmlString(strBuilder.ToString());
            return mvcStr;
        }
    }
}