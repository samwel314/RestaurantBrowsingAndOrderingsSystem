namespace RestaurantBrowsingAndOrderingsSystem.Helpers
{
    public class PaginationModel
    {
        public PaginationModel(int DataCount ,  int PageSize , int Active  ) 
        {
            if (Active >= PageSize)
                Active = 0; 

            this.PageSize = PageSize;
            PagesCount = DataCount  % 
                PageSize == 0 ? DataCount / PageSize :( DataCount / PageSize ) + 1 ;
            this.Active = Active ;
            Next = Active == PagesCount ? 1 : Active + 1;
            Previous = Active == 1 ? 1 : Active - 1;    

        }    
        public int PageSize { get; set; }   
        public int PagesCount { get; set; }  
        public int Next {  get; set; }      
        public int Previous { get; set; }   
        public int Active { get; set; }
    }
}
