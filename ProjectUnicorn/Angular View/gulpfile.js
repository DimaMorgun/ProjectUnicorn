/// <binding />
"use strict";

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify");

var exec = require('child_process').exec;

gulp.task('AngularBuild', function () {
  exec('ng build', function () {
    console.log('Angular have built!');
  });
});

gulp.task('AngularWatchBuild', function () {
  exec('ng build --watch', function () {
    console.log('Angular build run in watch mode.');
  });
});

gulp.task('InitElectron', function () {
  exec('dotnet electronize init', function () {
    console.log('Electron initizlized to project.');
  });
});

gulp.task('StartElectron', function () {
  exec('dotnet electronize start', function () {
    console.log('Electron have started.');
  });
});
