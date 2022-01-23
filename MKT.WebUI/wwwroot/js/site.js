// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

colorPool = [
    "#311B92", "#1A237E", "#0D47A1", "#E65100",
    "#63b598", "#ce7d78", "#ea9e70", "#a48a9e", "#c6e1e8", "#648177", "#0d5ac1",
    "#f205e6", "#1c0365", "#14a9ad", "#4ca2f9", "#a4e43f", "#d298e2", "#6119d0",
    "#d2737d", "#c0a43c", "#f2510e", "#651be6", "#79806e", "#61da5e", "#cd2f00",
    "#9348af", "#01ac53", "#c5a4fb", "#996635", "#b11573", "#4bb473", "#75d89e",
    "#2f3f94", "#2f7b99", "#da967d", "#34891f", "#b0d87b", "#ca4751", "#7e50a8",
    "#c4d647", "#e0eeb8", "#11dec1", "#289812", "#566ca0", "#ffdbe1", "#2f1179",
    "#935b6d", "#916988", "#513d98", "#aead3a", "#9e6d71", "#4b5bdc", "#0cd36d",
    "#250662", "#cb5bea", "#228916", "#ac3e1b", "#df514a", "#539397", "#880977",
    "#f697c1", "#ba96ce", "#679c9d", "#c6c42c", "#5d2c52", "#48b41b", "#e1cf3b",
    "#5be4f0", "#57c4d8", "#a4d17a", "#225b8", "#be608b", "#96b00c", "#088baf",
    "#f158bf", "#e145ba", "#ee91e3", "#05d371", "#5426e0", "#4834d0", "#802234",
    "#6749e8", "#0971f0", "#8fb413", "#b2b4f0", "#c3c89d", "#c9a941", "#41d158",
    "#fb21a3", "#51aed9", "#5bb32d", "#807fb", "#21538e", "#89d534", "#d36647",
    "#7fb411", "#0023b8", "#3b8c2a", "#986b53", "#f50422", "#983f7a", "#ea24a3",
    "#79352c", "#521250", "#c79ed2", "#d6dd92", "#e33e52", "#b2be57", "#fa06ec",
    "#1bb699", "#6b2e5f", "#64820f", "#1c271", "#21538e", "#89d534", "#d36647",
    "#7fb411", "#0023b8", "#3b8c2a", "#986b53", "#f50422", "#983f7a", "#ea24a3",
    "#79352c", "#521250", "#c79ed2", "#d6dd92", "#e33e52", "#b2be57", "#fa06ec",
    "#1bb699", "#6b2e5f", "#64820f", "#1c271", "#9cb64a", "#996c48", "#9ab9b7",
    "#06e052", "#e3a481", "#0eb621", "#fc458e", "#b2db15", "#aa226d", "#792ed8",
    "#73872a", "#520d3a", "#cefcb8", "#a5b3d9", "#7d1d85", "#c4fd57", "#f1ae16",
    "#8fe22a", "#ef6e3c", "#243eeb", "#1dc18", "#dd93fd", "#3f8473", "#e7dbce",
    "#421f79", "#7a3d93", "#635f6d", "#93f2d7", "#9b5c2a", "#15b9ee", "#0f5997",
    "#409188", "#911e20", "#1350ce", "#10e5b1", "#fff4d7", "#cb2582", "#ce00be",
    "#32d5d6", "#17232", "#608572", "#c79bc2", "#00f87c", "#77772a", "#6995ba",
    "#fc6b57", "#f07815", "#8fd883", "#060e27", "#96e591", "#21d52e", "#d00043",
    "#b47162", "#1ec227", "#4f0f6f", "#1d1d58", "#947002", "#bde052", "#e08c56",
    "#28fcfd", "#bb09b", "#36486a", "#d02e29", "#1ae6db", "#3e464c", "#a84a8f",
    "#911e7e", "#3f16d9", "#0f525f", "#ac7c0a", "#b4c086", "#c9d730", "#30cc49",
    "#3d6751", "#fb4c03", "#640fc1", "#62c03e", "#d3493a", "#88aa0b", "#406df9",
    "#615af0", "#4be47", "#2a3434", "#4a543f", "#79bca0", "#a8b8d4", "#00efd4",
    "#7ad236", "#7260d8", "#1deaa7", "#06f43a", "#823c59", "#e3d94c", "#dc1c06",
    "#f53b2a", "#b46238", "#2dfff6", "#a82b89", "#1a8011", "#436a9f", "#1a806a",
    "#4cf09d", "#c188a2", "#67eb4b", "#b308d3", "#fc7e41", "#af3101", "#ff065",
    "#71b1f4", "#a2f8a5", "#e23dd0", "#d3486d", "#00f7f9", "#474893", "#3cec35",
    "#1c65cb", "#5d1d0c", "#2d7d2a", "#ff3420", "#5cdd87", "#a259a4", "#e4ac44",
    "#1bede6", "#8798a4", "#d7790f", "#b2c24f", "#de73c2", "#d70a9c", "#25b67",
    "#88e9b8", "#c2b0e2", "#86e98f", "#ae90e2", "#1a806b", "#436a9e", "#0ec0ff",
    "#f812b3", "#b17fc9", "#8d6c2f", "#d3277a", "#2ca1ae", "#9685eb", "#8a96c6",
    "#dba2e6", "#76fc1b", "#608fa4", "#20f6ba", "#07d7f6", "#dce77a", "#77ecca"
];

function JsonTurkcelestir(data) {
    data = data.replace(/&quot;/g, '"');
    return stringTurkcelestir(data);
}

function stringTurkcelestir(data) {
    if (data !== undefined) {
        data = data.split("&#x131;").join("ı");
        data = data.split("&#x15E;").join("Ş");
        data = data.split("&#x15F;").join("ş");
        data = data.split("&#xFC;").join("ü");
        data = data.split("&#x11F;").join("ğ");
        data = data.split("&#xE7;").join("ç");
        data = data.split("&#xF6;").join("ö");
        data = data.split("&#x130;").join("İ");
        data = data.split("&#xD6;").join("Ö");
        data = data.split("&#xC7;").join("Ç");
        data = data.split("&#x11E;").join("Ğ");
        data = data.split("&#xDC;").join("Ü");
        return data;
    }

}

(function () {
    "use strict";

    var treeviewMenu = $('.app-menu');

    // Toggle Sidebar
    $('[data-toggle="sidebar"]').click(function (event) {
        event.preventDefault();
        $('.app').toggleClass('sidenav-toggled');
    });

    // Activate sidebar treeview toggle
    $("[data-toggle='treeview']").click(function (event) {
        event.preventDefault();
        if (!$(this).parent().hasClass('is-expanded')) {
            treeviewMenu.find("[data-toggle='treeview']").parent().removeClass('is-expanded');
        }
        $(this).parent().toggleClass('is-expanded');
    });

    // Set initial active toggle
    $("[data-toggle='treeview.'].is-expanded").parent().toggleClass('is-expanded');

    //Activate bootstrip tooltips
    $("[data-toggle='tooltip']").tooltip();

})();


function numberToPrice(v) {
    if (v == 0) { return '0,00'; }
    v = parseFloat(v);
    v = v.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
    v = v.split('.').join('*').split(',').join('.').split('*').join(',');
    return v + ' ₺';
}

var datatableConfig = {
    "caseInsensitive": false,
    dom: 'lBfrtip',
    columnDefs: [
        $('.mkt-datatable').data('mktDatatableSelect')
        ? {
            orderable: false,
            className: 'select-checkbox',
            targets: 0
        }
        : {}
    ],
    select:
        $('.mkt-datatable').data('mktDatatableSelect')
            ? {
                style: 'multi',
            }
            : false,
    buttons: [
        $('.mkt-datatable').data('mktDatatableSelect') ? { extend: 'selectAll', text: 'Tümünü Seç' } : undefined,
        $('.mkt-datatable').data('mktDatatableSelect')
        ? { extend: 'selectNone', text: 'Tüm Seçimleri Kaldır' }
        : undefined,
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            className: 'btn btn-success',
            exportOptions: { columns: $('.mkt-datatable').data('mktDatatableColumns') }
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            className: 'btn btn-danger',
            download: 'open',
            exportOptions: { columns: $('.mkt-datatable').data('mktDatatableColumns') }
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            className: 'btn btn-light',
            exportOptions: { columns: $('.mkt-datatable').data('mktDatatableColumns') }
        },
    ],
    initComplete: function() {
        this.api().columns().every(function() {
            var that = this;
            $('input', this.header()).on('keyup change clear',
                function() {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            if ($(this.header()).data('search') === 'select') {
                var column = this;
                var select =
                    $(`<select class="form-control" onchange="${$(this.header()).data('onchange')
                            }(this)"><option value=""></option></select>`)
                        .appendTo($(column.header()))
                        .on('change',
                            function() {
                                var val = $.fn.dataTable.util.escapeRegex(
                                    $(this).val()
                                );

                                column
                                    .search(val ? '^' + val + '$' : '', true, false)
                                    .draw();
                            });
                column.data().unique().sort().each(function(d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>');
                });
            }
        });
    }
};

function formatState(state) {
    if (!state.id) {
        return state.text;
    }
    return state.text;
};

var currencies = [];
var autoNumericConfig = {
    currencySymbol: "₺",
    decimalCharacter: ",",
    digitGroupSeparator: ".",
    currencySymbolPlacement: "s"
};

function initializePlugins() {
    setABBCollapse();

    initializeThirtPlugins();
}

var mktDatatable;
$.fn.dataTable.Buttons.defaults.dom.button.className = '';
function initializeThirtPlugins() {
    if (!$.fn.DataTable.isDataTable(mktDatatable)) {
        $('.mkt-datatable thead th').each(function () {
            $(this).addClass('text-center');
            var title = $(this).text();
            if (title !== "") {
                if ($(this).data('search') !== 'select') {
                    $(this).html(
                        `<span class="text-muted">${title}</span><input type="text" class="form-control" placeholder="search in ${title}" />`);
                } 
            }
        });

        mktDatatable = $('.mkt-datatable').DataTable(datatableConfig);
    }

    $('.mkt-select2').select2({
        templateResult: formatState,
        templateSelection: formatState,
        placeholder: $('.mkt-select2').closest('label').html(),
        width: '100%',
        escapeMarkup: function (m) { return m; }
    });

    $('.mkt-select2-dynamic-creation').select2({
        templateResult: formatState,
        templateSelection: formatState,
        placeholder: $('.mkt-select2').closest('label').html(),
        tags: true,
        width: '100%',
        escapeMarkup: function (m) { return m; }
    });

    $('.mkt-datepicker').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        todayBtn: "linked",
        language: "tr"
    });

    $.each(document.getElementsByClassName('mkt-currency'),
        function (index, item) {
            if (AutoNumeric.getAutoNumericElement(item) === null) {
                currencies.push(new AutoNumeric(item, autoNumericConfig));
            }
        });

    $('.mkt-popover-hover').popover({
        trigger: 'hover',
        placement: 'bottom'
    });

}

var mktDaterangePicker;
function initializeDateRangePicker() {
    function cb(start, end) {
        $('.mkt-daterangepicker span').html(start.format('MMMM D') + ' - ' + end.format('MMMM D'));
    }
    cb(moment().subtract(29, 'days'), moment());

    function cbmaxDateToday(start, end) {
        $('.mkt-daterangepicker span').html(start.format('MMMM D') + ' - ' + end.format('MMMM D'));
    }
    cbmaxDateToday(moment().subtract(29, 'days'), moment());


    mktDaterangePicker = $('.mkt-daterangepicker').daterangepicker({
        "opens": "auto",
        "locale": {
            "format": "YYYY/MM/DD",
            "separator": "-",
            "firstDay": 1
        },
        "startDate": moment().subtract(1,'days'),
        "endDate": moment(),
        ranges: {
            'Today': [moment().subtract(1,'days'), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last Week': [moment().subtract(7, 'days'), moment()],
            'Last 30 days': [moment().subtract(30, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        alwaysShowCalendars: true
    }, cb);


    mktDaterangePicker = $('.mkt-daterangepicker-max-date-today').daterangepicker({
        "opens": "auto",
        "maxDate": new Date(),
        "locale": {
            "format": "YYYY/MM/DD",
            "separator": "-",
            "firstDay": 1
        },
        "startDate": moment().subtract(1, 'days'),
        "endDate": moment(),
        ranges: {
            'Today': [moment().subtract(1,'days'), moment()],
            'Yesterday': [moment().subtract(2, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        alwaysShowCalendars: true
    }, cbmaxDateToday);

}

function makeSelect2(elementId, url, type, tags=false) {
    $(document.getElementById(elementId)).select2({
        tags: tags,
        ajax: {
            url: url,
            dataType: 'json',
            cache: false,
            delay: 50,
            data: function (params) {
                var query = {
                    term: params.term,
                    type: type,
                }
                return query;
            },
            processResults: function (data, page) {
                return data;
            },
            createTag: function (params) {
                var term = $.trim(params.term);
                if (term === '') {
                    return null;
                }
                return {
                    id: term,
                    text: term,
                    newTag: true // add additional parameters
                }
            },
        },
        
        templateResult: formatWithHelper
    });
}

function makeSelect2GenelTanimKategori(elementId, url, type, kategoriler,tags=false) {
    $(document.getElementById(elementId)).select2({
        tags: tags,
        ajax: {
            url: url,
            dataType: 'json',
            cache: false,
            delay: 50,
            data: function (params) {
                var query = {
                    term: params.term,
                    type: type,
                    kategoriler: JSON.stringify(kategoriler)
                }
                return query;
            },
            processResults: function (data, page) {
                return data;
            },
            createTag: function (params) {
                var term = $.trim(params.term);
                if (term === '') {
                    return null;
                }
                return {
                    id: term,
                    text: term,
                    newTag: true // add additional parameters
                }
            },
        },
        
        templateResult: formatWithHelper
    });
}

function formatWithHelper(state) {
    if (!state.id) {
        return state.text;
    }
    var $state;
    if (state.helpText) {
        $state = $(
            `<span>${state.text} - <span class=text-muted>${state.helpText}</span></span>`
        );
    } else {
        $state = $(
            '<span>' + state.text + '</span>'
        );
    }
    return $state;
};

function toggleScaleAnimationById(divId) {
    $(document.getElementById(divId)).toggle('clip', {}, 250);
}


// collapse olabilen card elemanlarını set ediyoruz
function setABBCollapse() {
    var collapseHeader = '<a href="#{collapseindex}" class="d-block card-header py-3" data-toggle="collapse" ' +
        'role="button"><h6 class="m-0 font-weight-bold text-primary">{abbtitle}</h6></a > ' +
        '<div class="collapse show" id="{collapseindex}" style=""><div class="card-body" ></div></div>';
    var collapseList = $('*[data-mkt-type="mkt-collapse"]');
    $.each(collapseList,
        function (index, collapseCard) {
            $(collapseCard).addClass("card shadow mb-3");
            var title = $(collapseCard).data('mkt-title');
            var tempHtml = $(collapseCard).html();
            $(collapseCard).empty();
            var tempCollapseHeader = collapseHeader.replace(new RegExp('{abbtitle}', 'gi'), title);
            tempCollapseHeader = tempCollapseHeader.replace(new RegExp('{collapseindex}', 'gi'), 'collapse' + index);
            $(collapseCard).append(tempCollapseHeader);
            $(collapseCard.getElementsByClassName("card-body")[0]).append(tempHtml);
        });
}

$(document).ready(function () {
    initializePlugins();
    initializeDateRangePicker();
});

function SuccessMesajGoster(title, message) {
    MesajGoster(title, message, "success");
}

function HataMesajGoster(title, message) {
    MesajGoster(title, message, "error");
}

function MesajGoster(title, message, status) {
    $(function () {
        Swal.fire(stringTurkcelestir(title), stringTurkcelestir(message), status);
    });
}

/**
 * enter tuşuna basınca postwithredirect butonunun click olma mekaniği araştırılıyor
 */
$(document).ready(function () {
    var postButtonlar = $('form button[onclick^="PostWith"]');
    $.each(postButtonlar,
        function (index, buton) {
            var form = buton.form;
            $(form).keypress(function (e) {
                if (e.which === 13 && !$(e.target).is('textarea')) {
                    buton.click();
                    return false;
                }
            });
        });
});

function PostWithFormRedirect(formSubmitButton) {

    return PostWithFunc(formSubmitButton,
        () => {
            window.location.href = $(formSubmitButton).parents('form').attr('action');
        });
}

function PostWithRedirect(formSubmitButton, successRedirect) {

    return PostWithFunc(formSubmitButton,
        () => {
            window.location.href = successRedirect;
        });
}

function PostWithFunc(formSubmitButton, successFunc) {
    Swal.fire({
        title: 'Please wait',
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });
    $.each(currencies,
        function (index, item) {
            if (item.domElement.nodeName.toLowerCase().includes("input")) {
                item.unformat();
            }
        });

    var $form = $(formSubmitButton).parents('form');
    $.ajax({
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            HataMesajGoster('Error', stringTurkcelestir(xhr.responseJSON.message));
            return false;
        },
        success: function (response, textStatus, xhr) {
            SuccessMesajGoster('Success', stringTurkcelestir(response.message));
            setTimeout(successFunc, 1300);
        },
        complete: function (data) {
            initializeThirtPlugins();
            Swal.close();
        }
    });
}


