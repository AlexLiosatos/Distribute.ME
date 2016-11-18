namespace DistributeMeProject {

    angular.module('DistributeMeProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: DistributeMeProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: DistributeMeProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('distributorproducts', {
                url: '/distributorproducts/:id',
                templateUrl: '/ngApp/views/distributorproducts.html',
                controller: DistributeMeProject.Controllers.DistributorProductsDetailsController,
                controllerAs: 'controller'
            })
            .state('restaurantproducts', {
                url: '/restaurantproducts/:id',
                templateUrl: '/ngApp/views/restaurantproducts.html',
                controller: DistributeMeProject.Controllers.RestaurantProductsDetailsController,
                controllerAs: 'controller'
            })
            .state('orderrestaurantproduct', {
                url: '/orderrestaurantproduct/:id',
                templateUrl: '/ngApp/views/orderrestaurantproduct.html',
                controller: DistributeMeProject.Controllers.RestaurantProductsDetailsController,
                controllerAs: 'controller'
            })
            .state('addrestaurantproduct', {
                url: '/addrestaurantproduct/:id',
                templateUrl: '/ngApp/views/addrestaurantproduct.html',
                controller: DistributeMeProject.Controllers.RestaurantProductsDetailsController,
                controllerAs: 'controller'
            })
            .state('adddistributorproduct', {
                url: '/adddistributorproduct/:id',
                templateUrl: '/ngApp/views/adddistributorproduct.html',
                controller: DistributeMeProject.Controllers.DistributorProductsDetailsController,
                controllerAs: 'controller'
            })
            .state('restaurant', {
                url: '/restaurant',
                templateUrl: '/ngApp/views/restaurant.html',
                controller: DistributeMeProject.Controllers.RestaurantController,
                controllerAs: 'controller'
            })
            .state('restaurantdetails', {
                url: '/restaurantdetails/:id',
                templateUrl: '/ngApp/views/restaurantdetails.html',
                controller: DistributeMeProject.Controllers.RestaurantDetailsController,
                controllerAs: 'controller'
            })
            .state('distributor', {
                url: '/distributor',
                templateUrl: '/ngApp/views/distributor.html',
                controller: DistributeMeProject.Controllers.DistributorController,
                controllerAs: 'controller'
            })
            .state('distributordetails', {
                url: '/distributordetails/:id',
                templateUrl: '/ngApp/views/distributordetails.html',
                controller: DistributeMeProject.Controllers.DistributorDetailsController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: DistributeMeProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: DistributeMeProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: DistributeMeProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: DistributeMeProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('DistributeMeProject').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('DistributeMeProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
