'use strict';

/* t-pagination */

/*  */

(function () {
    var PREFIX = "PAGINATION";
    var id = -1;
    function numPageToShow(positionNextToCurrent, nbPagesTotal, nbMaxNumPagesShowed, asc) {
        var numPages = [];
        var positionDebut = positionNextToCurrent;
        
        if (!asc) {
            positionDebut = positionNextToCurrent - nbMaxNumPagesShowed + 1;
        }

        var nbPagesRestante = nbPagesTotal - positionDebut + 1;
        var minNbPages = nbPagesRestante >= nbMaxNumPagesShowed ? nbMaxNumPagesShowed : nbPagesRestante;
        for (var i = positionDebut; i <= minNbPages + positionDebut - 1; i++) {
            numPages.push(i);
        }
        
        return numPages;
    };
    
    Polymer('t-pagination', {
        created: function () {
            this.positionDebut = 0;
            this.positionFin = 0;
            this.pageDebut = 0;
            this.pageFin = 0;
            this.nbPagesTotal = 0;
            this.perPage = 5;
            this.currentPage = 0;
            this.numPages = [];
            this.nbMaxNumPagesShowed = 5;
            this.canGoBack = false;
            this.canGoNext = false;
            this.totalItems = 0;
            this.doSearch = true;

            id++;
            this.idInstance = PREFIX + String(id + 1);
        },
        ready: function () {
            
        },
        attached: function () {
            Utilities.PreventDomPolymer(this, 'loaded');
        },
        detached: function () {
            Utilities.PreventDomPolymer(this, 'removed');
        },
        observe: {
            totalItems: 'paginationParamsChanged',
            perPage: 'paginationParamsChanged'
        },
        paginationParamsChanged: function(oldValue, newValue) {

            // calculer le nombre de page
            this.pageDebut = 0;
            this.pageFin = 0;
            this.currentPage = 0;

            var nbPages = Math.floor(this.totalItems / this.perPage);
            if (this.totalItems % this.perPage > 0)
                nbPages++;

            this.nbPagesTotal = nbPages;

            if (this.nbPagesTotal > 0) {
                this.changeNumPageToShow(true, 0);
            }          
        },
        changeCurrentPage: function (event, detail, sender) {
            if (event.target.templateInstance.model.num == this.currentPage)
                return;
            
            this.doSearch = true;
            if (this.canGoBack) {
                this.currentPage = event.target.templateInstance.model.num - 1;
                this.changeNumPageToShow(true, this.currentPage);
            } else {
                if (this.canGoNext) {
                    this.currentPage = event.target.templateInstance.model.num + 1;
                    this.changeNumPageToShow(false, this.currentPage);
                } else {
                    this.currentPage = 0;
                    this.changeNumPageToShow(true, this.currentPage);
                }
            }
        },
        currentPageChanged: function (oldValue, newValue) {
            //this.canGoBack = newValue > 1;
            //this.canGoNext = newValue < this.nbPagesTotal;

            //this.setPagePositions(newValue);
        },
        setPagePositions: function(currentPage) {
            this.positionDebut = currentPage == 0 ? 0 : this.perPage * (currentPage - 1) + 1;
            this.positionFin = currentPage == 0 ? 0 : Math.min(this.perPage * currentPage, this.totalItems);
        },
        goBack: function (event, detail, sender) {
            if (!this.canGoBack)
                return;
            
            //this.fire('go-back', { msg: { numNextPage: this.currentPage } });            
            this.doSearch = true;
            this.changeNumPageToShow(false, this.currentPage);
        },
        goNext: function(event, detail, sender) {
            if (!this.canGoNext)
                return;
            
            //this.fire('go-next', { msg: { numNextPage: this.currentPage } });            
            this.doSearch = true;

            this.changeNumPageToShow(true, this.currentPage);            
        },
        changeNumPageToShow: function (asc, currentPage) {            
            var nextPageAround = asc ? currentPage + 1 : currentPage - 1;

            // ou exclusif
            var isChangeable = null;

            if (asc)
                isChangeable = currentPage == this.pageFin;
            else
                isChangeable = currentPage == this.pageDebut;
            
            if (isChangeable) {
                this.numPages = numPageToShow(nextPageAround, this.nbPagesTotal, this.nbMaxNumPagesShowed, asc);
                this.pageDebut = this.numPages[0];
                this.pageFin = this.numPages[this.numPages.length - 1];
            }

            this.currentPage = nextPageAround;
            
            this.canGoBack = this.currentPage > 1;
            this.canGoNext = this.currentPage < this.nbPagesTotal;

            this.setPagePositions(this.currentPage);
            
            this.execSearch();
        },
        goBackNumPageToShow: function (event, detail, sender) {
            this.changeNumPageToShow(false, this.pageDebut);
        },
        goNextNumPageToShow: function (event, detail, sender) {
            this.changeNumPageToShow(true, this.pageFin);
        },
        execSearch: function () {
            if (this.doSearch)
                this.fire('current-page-changed', { msg: { positionDebut: this.positionDebut, positionFin: this.positionFin, numPage: this.currentPage, idInstance: this.idInstance } });
            else
                this.doSearch = 0;
        },
        setTotalItems: function(count) {
            this.doSearch = false;
            this.totalItems = count;
        },
        setPerPage: function(perPage) {
            this.doSearch = true;
            this.perPage = perPage;
        }
    });
})();