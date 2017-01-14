﻿var gulp = require('gulp');
var browserSync = require('browser-sync');
var nodemon = require('gulp-nodemon');
// var sass = require('gulp-sass');
// gulp.task('default', ['startServer', 'sass:watch'], function() {
gulp.task('default', ['startServer'], function() {
    console.log("Gulp default: Finshed!")
});

gulp.task('startServer', ['nodemon'], function() {
    browserSync.init(null, {
        proxy: "http://localhost:8081",
        files: ["./css/*", "./images/*", "*.html", "./app/*"],
        browser: "chrome",
        port: 8082,
    });
});

gulp.task('nodemon', function(cb) {

    var started = false;

    return nodemon({
        script: 'web_server.js'
    }).on('start', function() {
        // to avoid nodemon being started multiple times
        // thanks @matthisk
        if (!started) {
            cb();
            started = true;
        }
    });
});

// gulp.task('sass', function() {
//     return gulp.src('./scss/**/*.scss')
//         .pipe(sass().on('error', sass.logError))
//         .pipe(gulp.dest('./css'));
// });

// gulp.task('sass:watch', function() {
//     gulp.watch('./scss/**/*.scss', ['sass']);
// });

//gulp.task('default', ['buildTs', 'webpack', 'watchTs'], function () {
//    console.log("Gulp default: Finshed!")
//});



//gulp.task('watchServer', function () {
//    gulp.watch('web_server.js', ['resetServer']);
//})

//gulp.task('startServer', ['watchServer'], function () {
//    server.listen({ path: './web_server.js' });
//})

//gulp.task('resetServer', function () {
//    server.restart();
//});

//gulp.task('watchTs', function () {
//    gulp.watch(['Structure/**/*.{ts,tsx}'], ['webpack']);
//});

//gulp.task('buildTs', function () {
//    var jsDirectory = './src';

//    var tsProject = ts.createProject({
//        noImplicitAny: true,
//        suppressImplicitAnyIndexErrors: true,
//        jsx: 'react',
//        target: 'ES5',
//        removeComments: true,
//        declaration: true,
//        noLib: false,
//        module: 'commonjs'
//    });

//    var tsResult = gulp.src(['Structure/**/*.{ts,tsx}'])
//        .pipe(ts(tsProject));

//    return merge([
//        tsResult.js.pipe(gulp.dest(jsDirectory))
//    ]);
//});

//var webpack = require('webpack');

//gulp.task("webpack", ['buildTs'], function (callback) {
//    // run webpack
//    webpack({
//        entry: './src/ManageApp.js',
//        output: {
//            path: './',
//            filename: 'ManageApp.js',
//        },
//        plugins: [
//            // new webpack.optimize.UglifyJsPlugin({
//            //     compress: {
//            //         warnings: false
//            //     }
//            // }),
//            // new webpack.optimize.CommonsChunkPlugin({
//            //     name: 'main', // Move dependencies to our main file
//            //     children: true, // Look for common dependencies in all children,
//            // })
//        ]
//    }, function (err, stats) {
//        callback();
//    });
//});

//gulp.task("webpackUser", ['buildTs'], function (callback) {
//    webpack({
//        entry: './src/UserApp.js',
//        output: {
//            path: './',
//            filename: 'UserApp.js',
//        }
//    }, function (err, stats) {
//        callback();
//    });
//});

//gulp.task('watchTsUser', function () {
//    gulp.watch(['Structure/**/*.{ts,tsx}'], ['webpackUser']);
//});

//gulp.task('User', ['webpackUser', 'watchTsUser']);