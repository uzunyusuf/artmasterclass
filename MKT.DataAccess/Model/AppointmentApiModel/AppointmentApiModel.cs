using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.DataAccess.Model.AppointmentApiModel
{
    // AppointmentApiModel myDeserializedClass = JsonSerializer.Deserialize<AppointmentApiModel>(myJsonResponse);
    public partial class ClientDetails
    {
        [JsonPropertyName("accept_language")]
        public string AcceptLanguage { get; set; }

        [JsonPropertyName("browser_height")]
        public int? BrowserHeight { get; set; }

        [JsonPropertyName("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonPropertyName("browser_width")]
        public int? BrowserWidth { get; set; }

        [JsonPropertyName("session_hash")]
        public object SessionHash { get; set; }

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }
    }

    public partial class ShopMoney
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public partial class PresentmentMoney
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public partial class CurrentSubtotalPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class CurrentTotalDiscountsSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class CurrentTotalPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class CurrentTotalTaxSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public class DiscountCode
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public partial class NoteAttribute
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public partial class SubtotalPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class PriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class TaxLine
    {
        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("rate")]
        public double Rate { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("price_set")]
        public PriceSet PriceSet { get; set; }

        [JsonPropertyName("channel_liable")]
        public bool ChannelLiable { get; set; }
    }

    public partial class TotalDiscountsSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class TotalLineItemsPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class TotalPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class TotalShippingPriceSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class TotalTaxSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public partial class BillingAddress
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("province_code")]
        public string ProvinceCode { get; set; }
    }

    public partial class DefaultAddress
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("customer_id")]
        public object CustomerId { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("province_code")]
        public string ProvinceCode { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("default")]
        public bool Default { get; set; }
    }

    public partial class Customer
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("accepts_marketing")]
        public bool AcceptsMarketing { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("orders_count")]
        public int OrdersCount { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("total_spent")]
        public string TotalSpent { get; set; }

        [JsonPropertyName("last_order_id")]
        public object LastOrderId { get; set; }

        [JsonPropertyName("note")]
        public object Note { get; set; }

        [JsonPropertyName("verified_email")]
        public bool VerifiedEmail { get; set; }

        [JsonPropertyName("multipass_identifier")]
        public object MultipassIdentifier { get; set; }

        [JsonPropertyName("tax_exempt")]
        public bool TaxExempt { get; set; }

        [JsonPropertyName("phone")]
        public object Phone { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("last_order_name")]
        public string LastOrderName { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("accepts_marketing_updated_at")]
        public DateTime AcceptsMarketingUpdatedAt { get; set; }

        [JsonPropertyName("marketing_opt_in_level")]
        public object MarketingOptInLevel { get; set; }

        [JsonPropertyName("tax_exemptions")]
        public List<object> TaxExemptions { get; set; }

        [JsonPropertyName("sms_marketing_consent")]
        public object SmsMarketingConsent { get; set; }

        [JsonPropertyName("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonPropertyName("default_address")]
        public DefaultAddress DefaultAddress { get; set; }
    }

    public class DiscountApplication
    {
        [JsonPropertyName("target_type")]
        public string TargetType { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("value_type")]
        public string ValueType { get; set; }

        [JsonPropertyName("allocation_method")]
        public string AllocationMethod { get; set; }

        [JsonPropertyName("target_selection")]
        public string TargetSelection { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public partial class OriginLocation
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("province_code")]
        public string ProvinceCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }

    public partial class Property
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public partial class TotalDiscountSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public class AmountSet
    {
        [JsonPropertyName("shop_money")]
        public ShopMoney ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public PresentmentMoney PresentmentMoney { get; set; }
    }

    public class DiscountAllocation
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("amount_set")]
        public AmountSet AmountSet { get; set; }

        [JsonPropertyName("discount_application_index")]
        public int DiscountApplicationIndex { get; set; }
    }

    public partial class LineItem
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonPropertyName("fulfillable_quantity")]
        public int FulfillableQuantity { get; set; }

        [JsonPropertyName("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonPropertyName("fulfillment_status")]
        public object FulfillmentStatus { get; set; }

        [JsonPropertyName("gift_card")]
        public bool GiftCard { get; set; }

        [JsonPropertyName("grams")]
        public int Grams { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin_location")]
        public OriginLocation OriginLocation { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("price_set")]
        public PriceSet PriceSet { get; set; }

        [JsonPropertyName("product_exists")]
        public bool ProductExists { get; set; }

        [JsonPropertyName("product_id")]
        public object ProductId { get; set; }

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("taxable")]
        public bool Taxable { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("total_discount")]
        public string TotalDiscount { get; set; }

        [JsonPropertyName("total_discount_set")]
        public TotalDiscountSet TotalDiscountSet { get; set; }

        [JsonPropertyName("variant_id")]
        public object VariantId { get; set; }

        [JsonPropertyName("variant_inventory_management")]
        public string VariantInventoryManagement { get; set; }

        [JsonPropertyName("variant_title")]
        public string VariantTitle { get; set; }

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonPropertyName("duties")]
        public List<object> Duties { get; set; }

        [JsonPropertyName("discount_allocations")]
        public List<DiscountAllocation> DiscountAllocations { get; set; }
    }

    public partial class PaymentDetails
    {
        [JsonPropertyName("credit_card_bin")]
        public string CreditCardBin { get; set; }

        [JsonPropertyName("avs_result_code")]
        public object AvsResultCode { get; set; }

        [JsonPropertyName("cvv_result_code")]
        public string CvvResultCode { get; set; }

        [JsonPropertyName("credit_card_number")]
        public string CreditCardNumber { get; set; }

        [JsonPropertyName("credit_card_company")]
        public string CreditCardCompany { get; set; }
    }

    public partial class Order
    {
        public TblOrder LocationOrder { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("admin_graphql_api_id")]
        public string AdminGraphqlApiId { get; set; }

        [JsonPropertyName("app_id")]
        public int AppId { get; set; }

        [JsonPropertyName("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonPropertyName("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonPropertyName("cancel_reason")]
        public object CancelReason { get; set; }

        [JsonPropertyName("cancelled_at")]
        public object CancelledAt { get; set; }

        [JsonPropertyName("cart_token")]
        public string CartToken { get; set; }

        [JsonPropertyName("checkout_id")]
        public object CheckoutId { get; set; }

        [JsonPropertyName("checkout_token")]
        public string CheckoutToken { get; set; }

        [JsonPropertyName("client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonPropertyName("closed_at")]
        public object ClosedAt { get; set; }

        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }

        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("current_subtotal_price")]
        public string CurrentSubtotalPrice { get; set; }

        [JsonPropertyName("current_subtotal_price_set")]
        public CurrentSubtotalPriceSet CurrentSubtotalPriceSet { get; set; }

        [JsonPropertyName("current_total_discounts")]
        public string CurrentTotalDiscounts { get; set; }

        [JsonPropertyName("current_total_discounts_set")]
        public CurrentTotalDiscountsSet CurrentTotalDiscountsSet { get; set; }

        [JsonPropertyName("current_total_duties_set")]
        public object CurrentTotalDutiesSet { get; set; }

        [JsonPropertyName("current_total_price")]
        public string CurrentTotalPrice { get; set; }

        [JsonPropertyName("current_total_price_set")]
        public CurrentTotalPriceSet CurrentTotalPriceSet { get; set; }

        [JsonPropertyName("current_total_tax")]
        public string CurrentTotalTax { get; set; }

        [JsonPropertyName("current_total_tax_set")]
        public CurrentTotalTaxSet CurrentTotalTaxSet { get; set; }

        [JsonPropertyName("customer_locale")]
        public string CustomerLocale { get; set; }

        [JsonPropertyName("device_id")]
        public object DeviceId { get; set; }

        [JsonPropertyName("discount_codes")]
        public List<DiscountCode> DiscountCodes { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("estimated_taxes")]
        public bool EstimatedTaxes { get; set; }

        [JsonPropertyName("financial_status")]
        public string FinancialStatus { get; set; }

        [JsonPropertyName("fulfillment_status")]
        public object FulfillmentStatus { get; set; }

        [JsonPropertyName("gateway")]
        public string Gateway { get; set; }

        [JsonPropertyName("landing_site")]
        public string LandingSite { get; set; }

        [JsonPropertyName("landing_site_ref")]
        public object LandingSiteRef { get; set; }

        [JsonPropertyName("location_id")]
        public object LocationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("note")]
        public object Note { get; set; }

        [JsonPropertyName("note_attributes")]
        public List<NoteAttribute> NoteAttributes { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("order_number")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("order_status_url")]
        public string OrderStatusUrl { get; set; }

        [JsonPropertyName("original_total_duties_set")]
        public object OriginalTotalDutiesSet { get; set; }

        [JsonPropertyName("payment_gateway_names")]
        public List<string> PaymentGatewayNames { get; set; }

        [JsonPropertyName("phone")]
        public object Phone { get; set; }

        [JsonPropertyName("presentment_currency")]
        public string PresentmentCurrency { get; set; }

        [JsonPropertyName("processed_at")]
        public DateTime ProcessedAt { get; set; }

        [JsonPropertyName("processing_method")]
        public string ProcessingMethod { get; set; }

        [JsonPropertyName("reference")]
        public object Reference { get; set; }

        [JsonPropertyName("referring_site")]
        public string ReferringSite { get; set; }

        [JsonPropertyName("source_identifier")]
        public object SourceIdentifier { get; set; }

        [JsonPropertyName("source_name")]
        public string SourceName { get; set; }

        [JsonPropertyName("source_url")]
        public object SourceUrl { get; set; }

        [JsonPropertyName("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonPropertyName("subtotal_price_set")]
        public SubtotalPriceSet SubtotalPriceSet { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonPropertyName("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonPropertyName("total_discounts_set")]
        public TotalDiscountsSet TotalDiscountsSet { get; set; }

        [JsonPropertyName("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonPropertyName("total_line_items_price_set")]
        public TotalLineItemsPriceSet TotalLineItemsPriceSet { get; set; }

        [JsonPropertyName("total_outstanding")]
        public string TotalOutstanding { get; set; }

        [JsonPropertyName("total_price")]
        public string TotalPrice { get; set; }

        [JsonPropertyName("total_price_set")]
        public TotalPriceSet TotalPriceSet { get; set; }

        [JsonPropertyName("total_price_usd")]
        public string TotalPriceUsd { get; set; }

        [JsonPropertyName("total_shipping_price_set")]
        public TotalShippingPriceSet TotalShippingPriceSet { get; set; }

        [JsonPropertyName("total_tax")]
        public string TotalTax { get; set; }

        [JsonPropertyName("total_tax_set")]
        public TotalTaxSet TotalTaxSet { get; set; }

        [JsonPropertyName("total_tip_received")]
        public string TotalTipReceived { get; set; }

        [JsonPropertyName("total_weight")]
        public int TotalWeight { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("user_id")]
        public object UserId { get; set; }

        [JsonPropertyName("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("discount_applications")]
        public List<DiscountApplication> DiscountApplications { get; set; }

        [JsonPropertyName("fulfillments")]
        public List<object> Fulfillments { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonPropertyName("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }

        [JsonPropertyName("payment_terms")]
        public object PaymentTerms { get; set; }

        [JsonPropertyName("refunds")]
        public List<object> Refunds { get; set; }

        [JsonPropertyName("shipping_lines")]
        public List<object> ShippingLines { get; set; }
    }

    public partial class AppointmentApiModel
    {
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }

        public string NextLink { get; set; }
        public string PreviousLink { get; set; }

    }

}
