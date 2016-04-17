/// <binding AfterBuild='default' />

var gulp = require('gulp');
var gnewer = require('gulp-newer');

var src = "../drivers/";
var dest = "./bin/Debug/drivers/";

gulp.task('default', function () {
    return gulp.src(['../drivers/chromedriver.exe', './drivers/IEDriverServer.exe'], { base: src })
        .pipe(gnewer(dest))
        .pipe(gulp.dest(dest));
});