using RestaurantSystemModels.Models;


namespace RestaurantSystemDataAccess.Services
{
    public interface IMenuService
    {
        bool CreatMenu(Menu menu);
        Menu ?GetMenu(int id  , bool include = false);

        bool UpdateMenu (Menu model );    

        bool DeleteMenu(int id );   

    }


}
