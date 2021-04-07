using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;
using Microsoft.AspNetCore.Http;

namespace JobBoardWithAuth.Views
{
    public class JobPostingsController : Controller
    {
        private readonly JobBoardContext _context;

        public JobPostingsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: JobPostings
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobPosting.ToListAsync());
        }

        // GET: JobPostings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPosting
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        // GET: JobPostings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobPostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,Title,JobFunction,Description,Requirement,Responsibilities,Qualifications,Skills,ModifiedDate,CreatedDate,StartDate,EndDate,IsPublic,IsDraft,OwnerId")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                jobPosting.JobId = Guid.NewGuid();
                _context.Add(jobPosting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobPosting);
        }

        // GET: JobPostings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPosting.FindAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }
            return View(jobPosting);
        }

        // POST: JobPostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("JobId,Title,JobFunction,Description,Requirement,Responsibilities,Qualifications,Skills,ModifiedDate,CreatedDate,StartDate,EndDate,IsPublic,IsDraft,OwnerId")] JobPosting jobPosting)
        {
            if (id != jobPosting.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPosting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPostingExists(jobPosting.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobPosting);
        }

        // GET: JobPostings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPosting
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            return View(jobPosting);
        }

        // POST: JobPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jobPosting = await _context.JobPosting.FindAsync(id);
            _context.JobPosting.Remove(jobPosting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobPostingExists(Guid id)
        {
            return _context.JobPosting.Any(e => e.JobId == id);
        }


        [HttpPost, ActionName("Apply")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                JobApplication jobApplication = new JobApplication();
                jobApplication.JobApplicationId = Guid.NewGuid();
                jobApplication.JobId = Guid.Parse(form["JobId"].ToString());
                jobApplication.applicantId = form["Email"].ToString();
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
               
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
