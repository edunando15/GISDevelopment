// Longitude and latitude of the centre of Albania.
const albania = [19.818698, 41.327546];4

// Longitude and latitude of central Italy.
const centralItaly = [12.5, 42.5];

// Constant path for API endpoints.
const constantPath = '/api/'

// Types of entities used in the application.
const entityTypes = {
    ItalianRestaurant: constantPath + 'Restaurant/',
    ItalianPlaceOfWorship: constantPath + 'PlaceOfWorship/',
    ItalianMonument: constantPath + 'Monument/',
    ItalianShop: constantPath + 'Shop/',
    AlbanianMunicipality: constantPath + 'Municipality/'
};

const apiControllers = {
    Point: constantPath + 'UserPoint/',
    Line: constantPath + 'UserLine/',
    Polygon: constantPath + 'UserPolygon/'
}