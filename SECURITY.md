# Security Notes

Current hardening highlights:

- CSRF protection on sensitive POST endpoints
- Anti-forgery tokens used in forms and AJAX calls
- Role-based authorization for restricted actions
- Request payload validation before service calls
- Custom error pages to avoid leaking internals to end users

Before production go-live:

- Remove/demo-protect setup utilities
- Rotate all secrets and store them in hosting platform configuration
