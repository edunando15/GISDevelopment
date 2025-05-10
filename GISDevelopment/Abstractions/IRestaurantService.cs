using GISDevelopment.Models.DTOs;

namespace GISDevelopment.Abstractions;

public interface IRestaurantService
{
    /// <summary>
    /// Method used to add a Restaurant to the database.
    /// </summary>
    /// <param name="restaurantDTO"> The restaurant to add. </param>
    void AddRestaurant(RestaurantDTO restaurantDTO);
    
    /// <summary>
    /// Method used to update a Restaurant from the database.
    /// </summary>
    /// <param name="restaurantDTO"> The already modified Restaurant. </param>
    void UpdateRestaurant(RestaurantDTO restaurantDTO);
    
    /// <summary>
    /// Method used to delete a Restaurant from the database.
    /// </summary>
    /// <param name="id"> The id of the Restaurant to delete. </param>
    /// <returns> True if the Restaurant was deleted, false otherwise. </returns>
    bool DeleteRestaurant(int id);
    
    /// <summary>
    /// Method used to retrieve a Restaurant from the database.
    /// </summary>
    /// <param name="id"> The id of the Restaurant to retrieve. </param>
    /// <returns> The requested Restaurant if it exists, false otherwise. </returns>
    RestaurantDTO? GetRestaurant(int id);
    
    /// <summary>
    /// Method used to retrieve all the Restaurants from the database.
    /// </summary>
    /// <returns> A list containing all the Restaurants in the database. </returns>
    List<RestaurantDTO> GetAllRestaurants();
    
    /// <summary>
    /// Method used to retrieve all the Restaurants from the database,
    /// satisfying the search criteria.
    /// </summary>
    /// <param name="from"> Indicates the starting point of the result. </param>
    /// <param name="num"> Indicates the number of elements in the result. </param>
    /// <param name="totalCount"> Denotes the total count of Restaurants. </param>
    /// <returns> A List containing all the Restaurants satisfying the given criteria. </returns>
    List<RestaurantDTO> GetAllRestaurants(int from, int num, out int totalCount);
}