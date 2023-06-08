using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tiny.Toolkits
{

    /// <summary>
    ///  create new instance of the <see cref="PaginationBindableBase"/>
    /// </summary>
    public abstract class PaginationBindableBase : BindableBase
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private string oldSearchCondition = string.Empty;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync searchCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync gotoCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync nextPageCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync lastPageCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync previousPageCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RelayCommandAsync firstPageCommand;
        /// <summary>
        /// total page
        /// </summary>
        public virtual int TotalPage
        {
            get => GetValue(1);
            set => SetValue(value);
        }

        /// <summary>
        /// current page
        /// </summary>
        public virtual int CurrentPage
        {
            get => GetValue(1);
            set => SetValue(value);
        }

        /// <summary>
        /// the index of the jump page
        /// </summary>
        public virtual int TargetPage
        {
            get => GetValue(1);
            set => SetValue(value);
        }

        /// <summary>
        /// the count of per page
        /// </summary>
        public virtual int PageSize
        {
            get => GetValue(10);
            set => SetValue(value);
        }
        /// <summary> 
        /// SearchKeyword
        /// </summary>
        public virtual string SearchKeyword
        {
            get => GetValue(string.Empty);
            set => SetValue(value);
        }

        /// <summary>
        /// IsSearching
        /// </summary>
        public virtual bool IsSearching
        {
            get => GetValue(false);
            set => SetValue(value);
        }

        /// <summary>
        /// SearchCommand
        /// </summary>
        public virtual RelayCommandAsync SearchCommand => searchCommand ??= RelayCommand.Bind(async () =>
        {
            try
            {
                if (IsSearching)
                {
                    return;
                }

                IsSearching = true;
                string search = SearchKeyword ??= string.Empty;
                if (oldSearchCondition != search)
                {
                    CurrentPage = 1;
                }

                int totalCount = await Search(search, CurrentPage, PageSize);

                TotalPage = (int)Math.Ceiling(totalCount / (double)PageSize);

                oldSearchCondition = search ?? string.Empty;
            }
            finally
            {
                IsSearching = false;
            }
        });

        /// <summary>
        /// GotoCommand
        /// </summary>
        public virtual RelayCommandAsync GotoCommand => gotoCommand ??= RelayCommand.Bind(async () =>
        {

            if (TargetPage > TotalPage || CurrentPage == TargetPage)
            {
                return;
            }

            if (TargetPage < 1 || CurrentPage == 1)
            {
                return;
            }

            CurrentPage = TargetPage;

            await Search(SearchKeyword, CurrentPage, PageSize);


        });

        /// <summary>
        /// FirstPageCommand
        /// </summary>
        public virtual RelayCommandAsync FirstPageCommand => firstPageCommand ??= RelayCommand.Bind(async () =>
        {

            CurrentPage = 1;
            await SearchCommand?.ExecuteAsync();

        });

        /// <summary>
        /// PreviousPageCommand
        /// </summary>
        public virtual RelayCommandAsync PreviousPageCommand => previousPageCommand ??= RelayCommand.Bind(async () =>
        {
            if (CurrentPage == 1)
            {
                return;
            }

            CurrentPage -= 1;
            await SearchCommand?.ExecuteAsync();

        });

        /// <summary>
        /// LastPageCommand
        /// </summary>
        public virtual RelayCommandAsync LastPageCommand => lastPageCommand ??= RelayCommand.Bind(async () =>
        {
            CurrentPage = TotalPage;
            await SearchCommand?.ExecuteAsync();
        });

        /// <summary>
        /// NextPageCommand
        /// </summary>
        public virtual RelayCommandAsync NextPageCommand => nextPageCommand ??= RelayCommand.Bind(async () =>
        {
            if (CurrentPage == TotalPage)
            {
                return;
            }

            CurrentPage += 1;
            await SearchCommand?.ExecuteAsync();
        });






        /// <summary>
        ///     <para>keyword:keyword of search</para>
        ///     <para>currentPage:the number of page</para>
        ///     <para>pageSize:max count in a page</para>
        ///     <para>returns:the number of total count</para>
        /// </summary>
        /// <param name="keyword">keyword of search</param>
        /// <param name="currentPage">the number of page</param>
        /// <param name="pageSize">the count in a page</param>
        /// <returns>total count</returns>
        protected abstract Task<int> Search(string keyword, int currentPage, int pageSize);

    }
}