/// ArticlesVM.js
/// <reference path="../knockout-3.2.0.js" />

function IndexViewModel() {
    // data
    var self = this;
    self.articles = ko.observable();
    self.article = ko.observable();
    self.choosenArticle = ko.observable();
    self.apiUrl = 'http://localhost:50447/api/v1/articles/';

    self.getArticles = function () {
        $.get(self.apiUrl).done(function (data) {
            self.articles(data);
        });
    };

    self.getArticle = function (article) {
        $.get(self.apiUrl + article.Id).done(function (data) {
            self.article(data);
        });
    };
};

ko.applyBindings(IndexViewModel);