# Academy Students Directory

**NOTE:** This application employs .NET, C#, MVC5, HTML5, CSS3, JS, AngularJS 1.X, and WebAPI.

The purpose of this app is to display a table that selects, posts, puts, and deletes students information.

## AngularJS Directives

I currently have `angular-toastr`, `dirPagination`, and `ui.bootstrap` for my app.

## How the Table Works

The directory selects all students in the database on initiation of the page and displays with ng-repeat.
The table has functionalities for search/filter, display order, display number, and pagination.
`dirPagination` adds more features to the normal angular built-in functionalities for tables.

A modal form is displayed on click of `insert` or `edit`. 
Insert shows a blank form for student entry. 
Edit shows the corresponding student info that can be changed.
Delete button is shown only when modal is triggered with the Edit buttons.

`angular-toastr` displays success or error messages after $http method calls.