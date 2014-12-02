/// init.js
/// <reference path="require.js" />
/// <reference path="knockout-3.2.0.js" />


require(['knockout', 'ViewModel/ArticlesVM'], function (ko, ArticlesVM) {
    ko.applyBindings(new ArticlesVM());
});