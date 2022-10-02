Feature:Book a room in Deluxe Apartment

  @order
  Scenario: Book 1 room for 4 nights (1 Deluxe Apartment)
    Given I am on homepage
    When Select a valid date and number of nights and click book now
    And Under Deluxe Apartment select the most expensive package
    And Select any two add ons
    Then Validate all details - Date, no of nights, room type, rate, add on (extra services charges), total
    Then Add traveler details and payment method to CC
    Then Use a dummy Visa CC and complete payment
    Then Validate Booking complete msg
