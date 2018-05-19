ko.validation.init({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: 'invalidValidationMsg',
    decorateInputElement: true,
    errorElementClass: 'is-invalid'
}, true);
