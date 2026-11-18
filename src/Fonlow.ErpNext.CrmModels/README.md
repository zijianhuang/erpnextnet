ErpNext.NET CRM Models

# ERPNext data models and wrappers

Data models are mostly generated using Copilot with sample data of DocType from a running instance of ERPNext.

Then you can check either:
1. ErpNext database schema
1. Or `api/resource/DocType/Customer` to confirm the numeric types, DateOnly and DateTime etc.


And [EF Reverse Engineering] may generate POCO classes and DbContext, so the classes could be used as a reference to verify.

Remarks:
* ErpNext DB schma overlap with DocType fileds, however, not entirely.
* The ultimate solution should be that the development team of ERPNext provides JSON schema, hopefully in near future.


# Automatic Way in the Future

The following is the suggestion by M365 Copilot:

Short answer: **ERPNext does not provide a built‑in, one‑click way to generate .NET POCO classes**, but **yes — it is absolutely possible**, and many integrations do exactly this by **programmatically transforming DocType metadata into C# classes**.

Below is a clear, practical breakdown of how this works and the realistic approaches you can take.

***

## 1. What ERPNext actually exposes via REST

When you call:

    GET /api/resource/DocType/Warranty Claim

ERPNext returns the **full DocType metadata**, not just UI hints. This includes:

*   Field names (`fieldname`)
*   Data types (`fieldtype`)
*   Required flags (`reqd`)
*   Length, precision
*   Child tables (`Table` fields)
*   Link targets (`Link` fields)
*   Options (for Select, Link, Table, etc.)

Although ERPNext uses this metadata to generate UI, **it is also the authoritative schema definition** for that document type.

That makes it perfectly suitable as a source for code generation.

***

## 2. Mapping DocType fields to C# POCO properties

ERPNext field types map cleanly to .NET types.

### Common mappings

| ERPNext FieldType | Typical C# Type    |
| ----------------- | ------------------ |
| Data / Small Text | `string`           |
| Link              | `string`           |
| Select            | `string` or `enum` |
| Int               | `int`              |
| Float / Currency  | `decimal`          |
| Check             | `bool`             |
| Date              | `DateTime?`        |
| Datetime          | `DateTime?`        |
| Text / Long Text  | `string`           |
| Table             | `List<TChild>`     |

***

### Example: Warranty Claim fragment → POCO

**ERPNext field definition**

```json
{
  "fieldname": "customer",
  "fieldtype": "Link",
  "options": "Customer",
  "reqd": 1
}
```

**Generated C#**

```csharp
[JsonProperty("customer")]
public string Customer { get; set; }
```

***

### Child table example

If the DocType contains:

```json
{
  "fieldname": "items",
  "fieldtype": "Table",
  "options": "Warranty Claim Item"
}
```

You generate:

```csharp
[JsonProperty("items")]
public List<WarrantyClaimItem> Items { get; set; }
```

…and generate a separate POCO for `Warranty Claim Item` using the same process.

***

## 3. Handling ERPNext’s “system” fields

Every DocType also contains standard fields like:

*   `name`
*   `owner`
*   `creation`
*   `modified`
*   `modified_by`
*   `docstatus`

You usually want a **shared base class**:

```csharp
public abstract class ErpNextDocument
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("docstatus")]
    public int DocStatus { get; set; }

    [JsonProperty("creation")]
    public DateTime? Creation { get; set; }

    [JsonProperty("modified")]
    public DateTime? Modified { get; set; }
}
```

Then:

```csharp
public class WarrantyClaim : ErpNextDocument
{
    public string Customer { get; set; }
    public string Complaint { get; set; }
}
```

***

## 4. How people actually generate these classes

There are **three realistic approaches**.

***

### ✅ Option 1: Write a small code generator (most common)

Typical flow:

1.  Authenticate to ERPNext REST API
2.  Fetch DocType JSON
3.  Loop through `fields[]`
4.  Apply a mapping table (fieldtype → C# type)
5.  Emit `.cs` files using:
    *   T4 templates
    *   Scriban
    *   Handwritten string builders

✅ Pros:

*   Fully typed
*   Matches your ERPNext schema exactly
*   Version‑controlled
*   Can regenerate when DocTypes change

✅ This is what most ERPNext ⇄ .NET shops do

***

### ✅ Option 2: Use OpenAPI / JSON Schema generation (partial)

ERPNext **does not natively expose OpenAPI schemas**, but some teams:

*   Convert DocType JSON → JSON Schema
*   Feed schema into tools like:
    *   `NJsonSchema`
    *   `json2csharp`

⚠️ Downsides:

*   Tables and Links need manual fixing
*   Enums (Select fields) need post‑processing

***

### ✅ Option 3: Dynamic models (least recommended)

Use `Dictionary<string, object>` or `dynamic`.

⚠️ This avoids class generation but:

*   Loses compile‑time safety
*   Harder to maintain
*   Error‑prone with child tables

Fine for quick scripts, not for production systems.

***

## 5. Things to watch out for

### Fieldname vs PropertyName

ERPNext uses `snake_case`, C# usually uses `PascalCase`.

✅ Solution:  
Keep JSON names using attributes:

```csharp
[JsonProperty("warranty_expiry_date")]
public DateTime? WarrantyExpiryDate { get; set; }
```

***

### Select fields

ERPNext returns raw strings.

You can:

*   Keep as `string`
*   Or generate C# `enum` if options are stable

***

### Permissions

DocType metadata is public to authenticated users, but:

*   Some sites restrict `/DocType`
*   Use an API key with System Manager permissions

***

## 6. Is there an official ERPNext tool for this?

**No.**
As of today:

*   No official .NET SDK
*   No official code generator
*   REST API is intentionally generic

ERPNext expects consumers to build thin clients or generators around the metadata.

***

## 7. Recommended architecture

If you are building anything beyond a toy integration:

✅ **Generate POCOs**
✅ **Shared base document**
✅ **Separate namespace per DocType group**
✅ **Re‑generatable (do not hand‑edit generated files)**

***

## Final takeaway

*   ✅ ERPNext DocType definitions **are sufficient to generate .NET POCO classes**
*   ❌ There is **no built‑in generator**
*   ✅ Writing a small DocType → C# generator is the **correct and common approach**
*   ✅ The REST API is explicitly designed to support this use case

If you want, I can:

*   Sketch a minimal DocType → C# generator
*   Provide a fieldtype → C# mapping table
*   Show how to handle child tables cleanly
*   Or show how to integrate this with HttpClient + Newtonsoft.Json

Just tell me how far you want to take it.
