using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Way2Buy.HTMLHelpers
{
    public static class PageingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (var i = 1; i <= pageInfo.TotalPages; i++)
            {
                if (i == pageInfo.CurrentPage)
                {
                    var tag = new TagBuilder("span") {InnerHtml = i.ToString()};

                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");

                    tag.AddCssClass("btn btn-default");
                    result.Append(tag);
                }
                else
                {
                    var tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();
                    if (i == pageInfo.CurrentPage)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    tag.AddCssClass("pagination-link");
                    result.Append(tag);
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PageLinksForSearchPage(this HtmlHelper html, PageInfo pageInfo)
        {
            var result = new StringBuilder();
            for (var i = 1; i <= pageInfo.TotalPages; i++)
            {
                if (i == pageInfo.CurrentPage)
                {
                    var tag = new TagBuilder("span") { InnerHtml = i.ToString() };

                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");

                    tag.AddCssClass("btn btn-default");
                    result.Append(tag);
                }
                else
                {
                    var tag = new TagBuilder("a");
                    tag.MergeAttribute("href", "#");
                    tag.InnerHtml = i.ToString();
                    if (i == pageInfo.CurrentPage)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    tag.AddCssClass("pagination-link");
                    result.Append(tag);
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}