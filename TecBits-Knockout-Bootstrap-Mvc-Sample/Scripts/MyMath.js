/// <reference path="../require.js" />

define(function () {
    function add(a, b) {
        return a + b;
    }

    return {
        add: add
    };
});



//var MyMath = (function () {
//    function add(a, b) {
//        return a + b;
//    };

//    return {
//        add:add
//    };
//});

//console.log(MyMath.add(1,2));