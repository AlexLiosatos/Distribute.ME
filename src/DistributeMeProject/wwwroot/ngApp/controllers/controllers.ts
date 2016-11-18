namespace DistributeMeProject.Controllers {

    export class HomeController {
        public restaurants;
        public distributors;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            $http.get('api/restaurants').then((res) => {
                    this.restaurants = res.data;
                }),
                $http.get('api/distributors').then((res) => {
                    this.distributors = res.data;
                });
        }
    }

    export class DialogController {
        public restaurants;
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, public $http: ng.IHttpService,
            public $stateParams: ng.ui.IStateParamsService, public restaurant, public $state: ng.ui.IStateService) {
            $http.get('api/restaurants').then((res) => {
                this.restaurants = res.data;
                console.log(this.restaurants);
            });
        }

        public edit() {
            this.$uibModalInstance.close();
        }

        public ok() {
            this.$http.put('api/restaurants', this.restaurant).then((res) => {
                this.edit();
                this.$state.reload();
            });
        }

        public log(modal) {
            console.log(modal);
        }
    }

    export class AddController {
        public business;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            
        }
    }

    export class RestaurantController {
        public restaurants;
        public message;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService,
            public $uibModal: angular.ui.bootstrap.IModalService, private accountService: DistributeMeProject.Services.AccountService) {
            $http.get('api/restaurants').then((res) => {
                if (accountService.getClaim("IsAdmin")) {
                    $http.get(`api/restaurants`).then((res) => {
                        this.restaurants = res.data;
                        console.log(this.restaurants);

                        if (this.restaurants.length === 0) {
                            this.message = "You do not have a business listed, please add one.";
                        } else {
                            this.message = "";
                        }
                    });
                } else if (accountService.getClaim("IsRestaurant")) {
                    $http.get(`api/restaurants/restaurant`).then((res) => {
                        this.restaurants = res.data;
                        console.log(this.restaurants);
                        if (this.restaurants.length === 0) {
                            this.message = "You do not have a business listed, please add one.";
                        } else {
                            this.message = "";
                        }
                    });
                } else {
                    console.log("sdsdsdasda");
                }
            });
        }

        public add(restaurant) {
            this.$http.post('api/restaurants', restaurant).then((res) => {
                this.$state.reload();
            });
        }

        public edit(restaurant) {
            this.$http.put('api/restaurants', restaurant).then((res) => {
                this.$state.reload();
            });
        }

        public delete(id) {
            console.log(id);
            this.$http.delete('api/restaurants/'+ id).then((res) => {
                this.$state.reload();
            });
        }

        public showModal(restaurant: Object) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/dialog.html',
                controller: 'DialogController',
                controllerAs: 'modal',
                resolve: {
                    restaurant: () => restaurant
                },
                size: 'sm'
            });
        }
    }

    angular.module('DistributeMeProject').controller('DialogController', DialogController);


    export class DistributorController {
        public distributors;
        public message;
        public user;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService,
            public $uibModal: angular.ui.bootstrap.IModalService, private accountService: DistributeMeProject.Services.AccountService) {
            if (accountService.getClaim("IsAdmin")) {
                $http.get(`api/distributors`).then((res) => {
                    this.distributors = res.data;
                    console.log(this.distributors);

                    if (this.distributors.length === 0) {
                        this.message = "You do not have a business listed, please add one.";
                    } else {
                        this.message = "";
                    }
                });
            } else if(accountService.getClaim("IsDistributor")) {
                $http.get(`api/distributors/distributor`).then((res) => {
                    this.distributors = res.data;
                    console.log(this.distributors);
                    if (this.distributors.length === 0) {
                        this.message = "You do not have a business listed, please add one.";
                    } else {
                        this.message = "";
                    }
                });
                
            }
        }

        public add(distributor) {
            console.log(distributor);
            this.$http.post('api/distributors', distributor).then((res) => {
                this.$state.reload();
            });
        }

        public edit(distributor) {
            this.$http.put('api/distributors', distributor).then((res) => {
                this.$state.reload();
            });
        }

        public delete(id) {
            console.log(id);
            this.$http.delete('api/distributors/' + id).then((res) => {
                this.$state.reload();
            });
        }

        public showModal(distributor: Object) {
            console.log("Opened Modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/views/dialogdistributor.html',
                controller: 'DialogDistributorController',
                controllerAs: 'modal',
                resolve: {
                    distributor: () => distributor
                },
                size: 'sm'
            });
        }
    }

    export class DialogDistributorController {
        public distributors;
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, public $http: ng.IHttpService,
            public $stateParams: ng.ui.IStateParamsService, public distributor, public $state: ng.ui.IStateService) {
            console.log("Hitting Http Request");
            $http.get('api/distributors').then((res) => {
                this.distributors = res.data;
                console.log(this.distributors);
            });
            console.log("Finished Request");
        }

        public edit() {
            this.$uibModalInstance.close();
        }

        public ok() {
            this.$http.put('api/distributors', this.distributor).then((res) => {
                this.edit();
                this.$state.reload();
            });
        }
    }

    


    export class RestaurantDetailsController {
        public restaurant;
        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService, public $state: ng.ui.IStateService) {
            $http.get(`api/restaurants/${$stateParams['id']}`).then((res) => {
                this.restaurant = res.data;
                console.log(this.restaurant);
            });
        }
    }

    angular.module('DistributeMeProject').controller('DialogDistributorController', DialogDistributorController);


    export class DistributorDetailsController {
        public distributor;
        public products;
        public product;
        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService, public $state: ng.ui.IStateService) {
            $http.get(`api/distributors/${$stateParams['id']}`).then((res) => {
                this.distributor = res.data;
                console.log(this.distributor);
            });
        }
        
        public productDetails(id) {
            this.$http.get(`api/products/${this.$stateParams['id']}`).then((res) => {
                this.products = res.data;
            });
        }

    }



    export class DistributorProductsDetailsController {
        public products;
        public distName;

        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService, public $state: ng.ui.IStateService, public $uibModal: angular.ui.bootstrap.IModalService ) {
            $http.get(`api/products/${this.$stateParams['id']}`).then((res) => {
                this.products = res.data;
            });
            $http.get(`api/distributors/${this.$stateParams['id']}`).then((res) => {
                let dist = res.data[0];
                this.distName = dist.name;
            });
        }

        public add(product) {
            product.distributorName = this.distName;
            this.$http.post(`api/products`, product).then((res) => {
                console.log(product);
                this.$state.reload();
            });
        }

        public delete(id) {
            console.log(id);
            this.$http.delete('api/products/' + id).then((res) => {
                this.$state.reload();
            });
        }

        public showModal(product: Object) {
            console.log("Opened Modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/views/dialogdistributorproducts.html',
                controller: 'DialogDistributorProductsController',
                controllerAs: 'modal',
                resolve: {
                    product: () => product
                },
                size: 'sm'
            });
        }
    }


    export class DialogDistributorProductsController {
        public products;
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, public $http: ng.IHttpService,
            public $stateParams: ng.ui.IStateParamsService, public product, public $state: ng.ui.IStateService) {
            console.log("Hitting Http Request");
            $http.get('api/products').then((res) => {
                this.products = res.data;
                console.log(this.products);
            });
            console.log("Finished Request");
        }

        public edit() {
            this.$uibModalInstance.close();
        }

        public ok() {
            this.$http.put('api/products', this.product).then((res) => {
                this.edit();
                this.$state.reload();
            });
        }
    }

    angular.module('DistributeMeProject').controller('DialogDistributorProductsController', DialogDistributorProductsController);


    export class RestaurantProductsDetailsController {
        public products;
        public distributorProducts;
        public restaurantProducts;

        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService, public $state: ng.ui.IStateService, public $uibModal: angular.ui.bootstrap.IModalService) {
            $http.get(`api/products/${this.$stateParams['id']}`).then((res) => {
                this.products = res.data;
            });
            $http.get('api/products').then((res) => {
                this.distributorProducts = res.data;
            });
            $http.get(`api/restaurants/resprods/${this.$stateParams['id']}`).then((res) => {
                this.restaurantProducts = res.data;
            });
        }

        public add(product) {
            this.$http.post(`api/products`, product).then((res) => {
                console.log(product);
                this.$state.reload();
            });
        }

        public delete(id) {
            console.log(id);
            this.$http.delete('api/products/' + id).then((res) => {
                this.$state.reload();
            });
        }

        public consume(product) {
            this.$http.put(`api/restaurants/consume/${this.$stateParams['id']}`, product).then((res) => {
                console.log(res.data);
            });
        }

        public orderProduct(product) {
            this.$http.post(`api/restaurants/resprods/${this.$stateParams['id']}`, product).then((res) => {
                console.log(res.data);
                alert(`Success! You have just ordered a ${product.name}.  You can view it in your Product Inventory section.`);
            });
        }

        public showModal(product: Object) {
            console.log("Opened Modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/views/dialogrestaurantproducts.html',
                controller: 'DialogRestaurantProductsController',
                controllerAs: 'modal',
                resolve: {
                    product: () => product
                },
                size: 'sm'
            });
        }
    }


    export class DialogRestaurantProductsController {
        public products;
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, public $http: ng.IHttpService,
            public $stateParams: ng.ui.IStateParamsService, public product, public $state: ng.ui.IStateService) {
            console.log("Hitting Http Request");
            $http.get('api/products').then((res) => {
                this.products = res.data;
                console.log(this.products);
            });
            console.log("Finished Request");
        }

        public edit() {
            this.$uibModalInstance.close();
        }

        public ok() {
            this.$http.put('api/products', this.product).then((res) => {
                this.edit();
                this.$state.reload();
            });
        }
    }

    angular.module('DistributeMeProject').controller('DialogRestaurantProductsController', DialogRestaurantProductsController);


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class AboutController {
        public message = 'Distribute.Me is an application geared towards connecting restaurants and distributors while providing easy ways to manage inventory and products';
    }


}
