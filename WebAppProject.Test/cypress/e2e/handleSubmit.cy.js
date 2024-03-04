describe("Form Submission Tests", () => {
  beforeEach(() => {
    // Assuming your form is on index.html at the root
    cy.visit("http://localhost:5191/");
  });

  it("Correctly handles input with leading zeros", () => {
    cy.get("#numberInput").type("000123");
    cy.get("#form").submit();
    cy.get("#numberInput").should("have.value", "123");
  });

  it("Correctly handles input with leading zeros before decimal", () => {
    cy.get("#numberInput").type("000.12");
    cy.get("#form").submit();
    cy.get("#numberInput").should("have.value", "0.12");
  });

  it("Appends zero if decimal input has only one digit", () => {
    cy.get("#numberInput").type("0.5");
    cy.get("#form").submit();
    cy.get("#numberInput").should("have.value", "0.50");
  });

  it("Shows error for invalid input", () => {
    cy.get("#numberInput").type("abc");
    cy.get("#form").submit();
    cy.get("#message").should("contain", "Please enter a valid number.");
  });

  it("Validates the maximum digits before the decimal", () => {
    cy.get("#numberInput").type("1234567890123456");
    cy.get("#form").submit();
    cy.get("#message").should(
      "contain",
      "Input exceeds the maximum allowed digits before the decimal."
    );
  });
});
