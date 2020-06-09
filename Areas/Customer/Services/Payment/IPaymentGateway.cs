namespace Easy.Commerce.Areas.Customer.Services.Payment
{
    interface IPaymentGateway
    {
        string InitiatePayment();
    }
}
