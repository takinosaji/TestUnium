/// <binding AfterBuild='default' />

var gulp = require('gulp');
var gnewer = require('gulp-newer');

var src = "../drivers";
var dest = ["./bin/Debug/net461/drivers",
            "./bin/Release/net461/drivers",
            "./bin/Release/net46/drivers",
            "./bin/Release/net452/drivers",
            "./bin/Release/net451/drivers",
            "./bin/Release/net45/drivers"];

gulp.task('default', function () {
    for (var i = 0; i < dest.length; i++) {
        gulp.src(['../drivers/**'], { base: src })
            .pipe(gnewer(dest[i]))
            .pipe(gulp.dest(dest[i]));
    }
});