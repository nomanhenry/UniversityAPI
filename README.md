
UniversityAPI is a RESTful API developed to manage university-related entities including students, subjects, lectures, and lecture theatres. Built with clean architecture principles, it ensures a well-structured and maintainable codebase.

Key Features
Enrollment Management: Students can enroll in subjects with business rules enforced to maintain lecture theatre capacity and weekly lecture limits.
Notification System: Successful enrollments trigger a simulated notification by writing to a file.
Technical Details
Architecture: Follows clean architecture principles to separate concerns into domain, application, infrastructure, and presentation layers.
Persistence: Utilizes an in-memory database for data storage, ensuring fast and simple management during development.
