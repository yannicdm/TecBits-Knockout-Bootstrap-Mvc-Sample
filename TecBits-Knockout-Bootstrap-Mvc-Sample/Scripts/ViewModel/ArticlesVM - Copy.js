﻿/// ArticlesVM.js
/// <reference path="../knockout-3.2.0.js" />
/// <reference path="../require.js" />

<<<<<<< HEAD

$(document).ready(function () {
    ko.applyBindings(IndexViewModel);
});

function IndexViewModel() {
    // data
    var self = this;
    self.articles = ko.observable();
    self.article = ko.observable();
    self.choosenArticle = ko.observable();
    self.apiUrl = 'http://localhost:50447/api/v1/articles/';
=======
    function ArticlesViewModel() {
        // data
        var self = this;
        self.articles = ko.observable();
        self.article = ko.observable();
        self.choosenArticle = ko.observable();
        self.apiUrl = 'http://localhost:50447/api/v1/articles/';
>>>>>>> origin/master

        self.getArticles = function () {
            $.get(self.apiUrl).done(function (data) {
                self.articles(data);
            });
        };

<<<<<<< HEAD
    self.getArticle = function (article) {
        $.get(self.apiUrl + article.Id).done(function (data) {
            self.article(data);
        });
    };

    self.getArticles();

};


=======
        self.getArticle = function (article) {
            $.get(self.apiUrl + article.Id).done(function (data) {
                self.article(data);
            });
        };

        self.getArticles();
};

ko.applyBindings(ArticlesViewModel);
>>>>>>> origin/master