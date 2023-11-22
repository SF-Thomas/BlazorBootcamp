redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51O0ggfC2yVNBO24pcafQNuwLa7TDX5pD48CAqUKHAQxFDqyhTAE6dPywD9PK4eyuPFnHM4lDIp3P3YQypebR0j7Y00IHkDept7");
    stripe.redirectToCheckout({ sessionId: sessionId });
}