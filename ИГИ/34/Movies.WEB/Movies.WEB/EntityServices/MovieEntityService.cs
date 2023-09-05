using Microsoft.AspNetCore.Http;
using Movies.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.WEB.EntityServices
{
    public class MovieEntityService
    {
        public enum SortState
        {
            NameAsc,
            NameDesc
        }
        public IQueryable<MovieDTO> Filter(IQueryable<MovieDTO> movies, string selectedMolvieName)
        {
            if (!string.IsNullOrEmpty(selectedMolvieName))
            {
                movies = movies.Where(p => p.Name.Contains(selectedMolvieName));
            }
            return movies;
        }

        public IQueryable<MovieDTO> Sort(IQueryable<MovieDTO> movies, SortState sortState)
        {
            switch (sortState)
            {
                case SortState.NameAsc:
                    movies = movies.OrderBy(p => p.Name);
                    break;
                case SortState.NameDesc:
                    movies = movies.OrderByDescending(p => p.Name);
                    break;
            }
            return movies;
        }

        public IQueryable<MovieDTO> Paging(IQueryable<MovieDTO> movies, bool isFromFilter, int page, int pageSize)
        {
            if (isFromFilter)
            {
                page = 1;
            }
            return movies.Skip(((int)page - 1) * pageSize).Take(pageSize);
        }

        public void GetFilterCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilterForm, ref string selectedName)
        {
            if (string.IsNullOrEmpty(selectedName))
            {
                if (!isFromFilterForm)
                {
                    cookies.TryGetValue(GetUsernameFromEmail(username) + "movieSelectedName", out selectedName);
                }
            }
        }

        public void GetSortPagingCookiesForUserIfNull(IRequestCookieCollection cookies, string username, bool isFromFilter, ref int? page, ref SortState? sortState)
        {
            if (!isFromFilter)
            {
                if (page == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "moviePage", out string pageStr))
                    {
                        page = int.Parse(pageStr);
                    }
                }
                if (sortState == null)
                {
                    if (cookies.TryGetValue(GetUsernameFromEmail(username) + "movieSortState", out string sortStateStr))
                    {
                        sortState = (SortState)Enum.Parse(typeof(SortState), sortStateStr);
                    }
                }
            }
        }

        public void SetDefaultValuesIfNull(ref string selectedName, ref int? page, ref SortState? sortState)
        {
            selectedName ??= "";
            page ??= 1;
            sortState ??= SortState.NameAsc;
        }

        public void SetCookies(IResponseCookies cookies, string username, string selectedName, int? page, SortState? sortState)
        {
            cookies.Append(GetUsernameFromEmail(username) + "movieSelectedName", selectedName);
            cookies.Append(GetUsernameFromEmail(username) + "moviePage", page.ToString());
            cookies.Append(GetUsernameFromEmail(username) + "movieSortState", sortState.ToString());
        }

        public string GetUsernameFromEmail(string email)
        {
            return email.Split('@')[0];
        }
    }
}
