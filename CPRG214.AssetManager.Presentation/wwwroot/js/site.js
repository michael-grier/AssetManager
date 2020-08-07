////// ASSET / SEARCH //////

// on button click, filter assets returned by asset type selected in dropdown
$(document).ready(() => {
    $("#uxFilterAssets").click(() => {
        var assetTypeID = $("#uxAssetTypes").val();
        $.ajax({
            method: 'GET',
            url: '/Asset/GetAssetsByType',
            data: { id: assetTypeID }
        }).done((result, statusText, xhdr) => {
            $("#uxDisplay").html(result);
        });
    });
});
