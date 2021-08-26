var tarefas = (function () {
    var config = {
        url: {
            post: '',
            getTarefas: ''
        }
    };

    var init = function ($config) {
        config = $config;
        getGrid();

    }

    var post = function () {
        debugger;
        var usuario = $("#form").serializeObject();

        $.post(config.url.post, {
            usuario: $("#form").serializeObject()
        }).done(function () {
            window.location = 'Tarefas/Index';
        }).fail(function (xhr) {
            alert(xhr.responseText);
        });
    };

    var getGrid = function () {
        debugger;
        $.get(config.url.getTarefas).done(function (data) {
            $("#divGrid").html(data);
        }).fail(function (xhr) {
            alert(xhr.responseText);
        });
    };

    return {
        init: init,
        post: post,
        getGrid: getGrid
    };
})();