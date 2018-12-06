var applicationCacheIsDemandUpdating = false;

    window.applicationCache.addEventListener('updateready', function (e) {
        if (window.applicationCache.status == window.applicationCache.UPDATEREADY) {
            if (applicationCacheIsDemandUpdating) {
                // Browser downloaded a new app cache.
                if (confirm('Une nouvelle version de cette application est disponible. Désirez-vous obtenir la mise à jour ?')) {
                    window.location.reload();
                }

                applicationCacheIsDemandUpdating = false;
            }
        } else {
            // Manifest didn't changed. Nothing new to server.
        }
    }, false);

    var applicationCacheCheckUpdateOnLine = function () {
        setTimeout(function () {
            window.applicationCache.update();
            applicationCacheIsDemandUpdating = true;

            applicationCacheCheckUpdateOnLine();
        }, 600000);
    }

    var uri = window.location.toString();
    if (uri.indexOf("index.html") > 0) {
        var clean_uri = uri.substring(0, uri.indexOf("index.html"));
        window.history.replaceState({}, document.title, clean_uri);
    }

    applicationCacheCheckUpdateOnLine();




    var printDivById = function (divName) {

        var printContents;

        try {
            var printContents = document.querySelector(divName).innerHTML;
        } catch (e) {
            alert("Zone d'impression non définie!");
            return;
        }

        doPrinting(printContents);
    }

    var printDivByClass = function (className) {
        var divToPrint;
        var printContents;

        try {
            divToPrint = document.querySelector(className);
            var printContents = divToPrint.innerHTML;
        } catch (e) {
            alert("Zone d'impression non définie!");
            return;
        }

        doPrinting(divToPrint);
    }

    function doPrinting(content) {
        /*var doc = new jsPDF();
         doc.fromHTML(content.html(), 15, 15, {
         'width': 170
         });
         doc.save('sample-file.pdf');*/
        /*var html2obj = html2canvas(content);
         var queue = html2obj.parse();
         var canvas = html2obj.render(queue);
         var img = canvas.toDataURL();
         window.open(img);*/
        html2canvas(content, {
            onrendered: function (canvas) {
                var img = canvas.toDataURL();
                var originalContents = document.body.innerHTML;
                document.body.innerHTML = "<html><head><title></title></head><body><img src=" + img + " /></body>";
                window.print();
                document.body.innerHTML = originalContents;
                window.open(img);
            }
        });
        /*var originalContents = document.body.innerHTML;
         document.body.innerHTML = "<html><head><title></title></head><body>" + content + "</body>";
         window.print();
         document.body.innerHTML = originalContents;*/
    }