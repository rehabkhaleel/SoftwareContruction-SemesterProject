using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Insurancce.Models;
using InsuranceManagementSystem.Models;

public class DocumentController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly string _uploadPath = "wwwroot/uploads";

    public DocumentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Upload form
    public IActionResult Upload()
    {
        return View();
    }

    // POST: Handle document upload
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            try
            {
                // Validate file extension
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".jpg", ".jpeg", ".png", ".gif" };
                string fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    ViewBag.Message = "Invalid file type. Only PDF, Word, Excel, and Image files are allowed.";
                    return View();
                }

                // Optional: Validate file size (max 10MB)
                if (file.Length > 10 * 1024 * 1024)
                {
                    ViewBag.Message = "File size exceeds the maximum limit of 10MB.";
                    return View();
                }

                // Generate file path
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), _uploadPath, fileName);

                // Ensure the directory exists
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), _uploadPath)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), _uploadPath));
                }

                // Save the file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Save file metadata to the database
                var document = new DocumentModel
                {
                    FileName = fileName,
                    FilePath = filePath,
                    UploadDate = DateTime.Now
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();

                ViewBag.Message = "File uploaded successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
        }
        else
        {
            ViewBag.Message = "Please select a file to upload.";
        }

        return View();
    }
}
