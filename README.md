# Playwright C# NUnit Google Tests

This project demonstrates automated web UI testing using **Playwright** with **C#** and **NUnit**, following the **Page Object Model (POM)** design pattern. It includes tests for navigating to Google and performing a search.

## Project Structure

The project is organized to promote maintainability and readability:

* **`PlaywrightSample/`**: The root directory for the test solution.
    * **`Framework/`**: Contains core framework components, including Page Objects.
        * **`GooglePage.cs`**: Implements the Page Object Model for the Google search page. This class encapsulates:
            * Locators for elements on the Google page (e.g., search input).
            * Action methods that define interactions with the page (e.g., `GoTo()`, `Search()` ).
            * Getter methods to retrieve the state of the page (e.g., `GetPageTitle()`, `GetCurrentUrl()`, `GetFirstSearchResultHeadingText()`).
    * **`Tests/`**: Contains the NUnit test classes.
        * **`BaseTest.cs`**: Contains the foundational setup and teardown logic for Playwright. It initializes the `IPlaywright`, `IBrowser`, and `IPage` instances before each test and disposes of them afterward. This class uses NUnit's `[TestFixture]` and `[SetUp]`/`[TearDown]` attributes for test lifecycle management.
        * **`GoogleTest.cs`**: Contains the actual NUnit test cases for Google.
            * It inherits from `BaseTest.cs` to leverage the shared Playwright setup and teardown.
            * It uses an instance of `GooglePage.cs` to interact with the Google website.
            * All assertion logic (`Assert.That()`) resides within this test class, ensuring that tests clearly define what is being verified.

## Getting Started

### Prerequisites

* **.NET SDK:** Ensure you have a compatible .NET SDK installed (e.g., .NET 6, 7, or 8).
* **Playwright Browsers:** Playwright requires browser binaries. These are usually installed automatically when you first run Playwright tests or you can install them manually.

### Installation

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/harbourc/PlaywrightSample.git
    cd PlaywrightSample
    ```

2.  **Restore dependencies:** Navigate to the project directory and restore the NuGet packages.
    ```bash
    dotnet restore
    ```

3.  **Install Playwright Browsers (if not already installed):**
    Playwright will typically prompt you to install browsers the first time you run a test. If not, or if you prefer to do it manually:
    ```bash
    dotnet playwright install
    ```

## Running Tests

You can run the tests using the .NET CLI from the `PlaywrightSample` directory:

```bash
dotnet test PlaywrightSample.csproj
