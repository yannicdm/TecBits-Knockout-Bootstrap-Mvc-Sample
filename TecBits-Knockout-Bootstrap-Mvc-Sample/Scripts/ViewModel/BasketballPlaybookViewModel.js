/// <reference path="../knockout-3.2.0.js" />
/// <reference path="../jquery-1.9.1.intellisense.js" />
/// <reference path="../jquery.simplemodal.js" />

$(function () {
    //$("#tagDialog").hide();
    var data = [
        { Id: ko.observable(1), Name: ko.observable("Ball handling") },
        { Id: ko.observable(2), Name: ko.observable("Passing") },
        { Id: ko.observable(3), Name: ko.observable("Shooting") },
        { Id: ko.observable(4), Name: ko.observable("Rebounding") },
        { Id: ko.observable(5), Name: ko.observable("Transition") },
        { Id: ko.observable(6), Name: ko.observable("Defense") },
        { Id: ko.observable(7), Name: ko.observable("Team offense") },
        { Id: ko.observable(8), Name: ko.observable("Team defense") }
    ];

    var viewModel = {
        // data
        tags: ko.observableArray(data),
        tagToAdd: ko.observable(''),
        selectedTag: ko.observable(null),

        // behavior
        addTag: function () {
            this.tags.push({ Name: ko.observable(this.tagToAdd()) });
            this.tagToAdd('');
        },

        selectTag: function () {
            console.log(this.Id + ': ' + this.Name);
            viewModel.selectedTag(this);
            console.log(viewModel.selectedTag());
        }
    };

    $(document).on("click", ".tag-delete", function () {
        var itemToRemove = ko.dataFor(this);
        console.log(itemToRemove.Name);
        viewModel.tags.remove(itemToRemove);
    });

    $(document).on("click", ".tag-edit", function () {

        $('#tagDialog').dialog({
            buttons: {
                Save: function () { $(this).dialog('close'); },
                Cancel: function () { $(this).dialog('close'); }
            }
        });
        console.log(viewModel.selectedTag().Name);
    });

    ko.applyBindings(viewModel);

});