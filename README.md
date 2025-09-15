# Visitor Registration 🚀  

## Om projektet  
Detta är mitt individuella skolprojekt där jag har byggt ett enkelt besöksregistreringssystem.  
Projektet är uppdelat i tre delar:  

- **Frontend** – HTML, CSS och JavaScript. Ligger på GitHub Pages.  
- **Backend** – Azure Function App (`app-register-visitor`) som tar emot och sparar registreringar.  
- **Databas** – Azure Cosmos DB (`visitor-cosmos-db`) där alla besök sparas.  

Jag använder även Application Insights för loggning och felsökning.  

---

## Funktioner  
- Användaren kan skriva in sitt namn i ett formulär.  
- Namnet skickas till backend och sparas i databasen.  
- En bekräftelse visas om allt går bra.  
- Allt loggas i Azure så jag kan följa vad som händer.  

---

## Projektstruktur  
```bash
📦 visitor-registration
 ┣ 📜 index.html              # Frontend
 ┣ 📜 style.css               # Design
 ┣ 📜 script.js               # JavaScript (anropar backend)
 ┣ 📜 RegistrationTrigger.cs  # Azure Function (backend)
 ┗ 📜 README.md               # Dokumentation
