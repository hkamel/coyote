// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

var awaInitialized = false;

function addTelemetryTag() {
    if (!awaInitialized) {
        awaInitialized = true;
        // awaConfig is defined in awa.html.
        awaConfig.userConsented = true;
        awa.init(awaConfig);
    }
}

function hideBanner(){
    $(".cookie-banner").hide();
}


$(document).ready(function () {

    // cookie banner callbacks, if consent is enabled, then we can enable the analytics.
    if (typeof (mscc) === 'undefined' || mscc.hasConsent()) {
        addTelemetryTag();
        hideBanner();
    } else {
        mscc.on('consent', addTelemetryTag);
        mscc.on('hide', hideBanner);
    }

});