function swInstall(event) {
    console.info("installing")
    event.waitUntil(
        caches.open('v1').then((cache) => {
            return cache.addAll([
                './',
                './css/site.css',
                './js/site.js',
                './favicon.ico',
                './js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0',
                './lib/bootstrap/dist/js/bootstrap.bundle.min.js',
                './lib/jquery/dist/jquery.min.js',
                './lib/bootstrap/dist/css/bootstrap.min.css ',
                './JobApplications',
                './Candidates',
                './Educations',
                './Employers',
                './Experiences',
                './Resumes',
                './JobPostings',
                './Home'

            ])
        })
    )
}

self.addEventListener('install', swInstall);

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (cacheResponse) {
            return cacheResponse || fetch(event.request)
        }).catch(() => {
            console.log("offline")
        })
    )
})