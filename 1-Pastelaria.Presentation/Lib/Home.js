var home = (function () {
    var config = {
        url: {
            post: '',
            get: ''
        }
    };

    var init = function ($config) {
        config = $config;
    }

    var post = function (form) {
        debugger;
        var obj = $(form).serializeObject();

        $.post(config.url.post,
            {
                obj
            }).success(function () {
                alert("usuario cadastrado com sucesso");
            }).error(function (xhr) {
                alert(xhr.responseText);
            });
    };

    //var getGrid = function () {
    //    debugger;
    //    $.get(config.url.get).success(function (data) {
    //        alert(data);
    //        $("#grid").html(data);
    //    }).error(function (xhr) {
    //        alert(xhr.responseText);
    //    });
    //};

    return {
        init: init,
        post: post
    };
})();