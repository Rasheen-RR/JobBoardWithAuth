// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function cache() {
    let isCached = false
    offlineBtn.on('click', async () => {
        let cache = await caches.open('offline-jobs').then((cache) => {
            isCached = await cache.match(window.location.href)

            let cacheItem = () => {
                cache.add(window.location.href)
            }

            if (cached) {
                offlineBtn.val('Remove from cache')

                cacheItem = () => {
                    cache.delete(windows.location.href)
                }
            } else {
                offlineBtn.val('Add to cache')
            }
        })

        cacheItem();
    })
}