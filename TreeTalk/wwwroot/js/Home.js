// Wrap everything in a document ready handler
$(document).ready(function () {
    // Theme toggling functionality
    const themeToggle = $('#themeToggle');
    const lightIcon = $('#lightIcon');
    const darkIcon = $('#darkIcon');
    const htmlElement = $(document.documentElement);

    // Initialize theme
    function initializeTheme() {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme) {
            htmlElement.attr('data-bs-theme', savedTheme);
            updateThemeIcon(savedTheme);
        } else {
            const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
            const initialTheme = prefersDark ? 'dark' : 'light';
            htmlElement.attr('data-bs-theme', initialTheme);
            updateThemeIcon(initialTheme);
        }
    }

    function updateThemeIcon(theme) {
        if (theme === 'dark') {
            lightIcon.addClass('d-none');
            darkIcon.removeClass('d-none');
        } else {
            darkIcon.addClass('d-none');
            lightIcon.removeClass('d-none');
        }
    }

    // Initialize theme on page load
    initializeTheme();

    // Theme toggle click handler
    themeToggle.click(function () {
        const currentTheme = htmlElement.attr('data-bs-theme') || 'light';
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
        htmlElement.attr('data-bs-theme', newTheme);
        localStorage.setItem('theme', newTheme);
        updateThemeIcon(newTheme);
    });

    // Comment functionalities
    let activeReplyForm = null;

    // Use event delegation for dynamic elements
    $(document)
        // Toggle comments section for posts
        .on('click', '.comment-toggle-btn', function () {
            var postId = $(this).data("post-id");
            var commentsContainer = $("#comments-" + postId);

            if (commentsContainer.hasClass("d-none")) {
                commentsContainer.removeClass("d-none");
                commentsContainer.find(".child-comments").addClass("d-none");
                $(this).find(".toggle-icon").removeClass("bi-chevron-down").addClass("bi-chevron-up");
            } else {
                commentsContainer.addClass("d-none");
                $(this).find(".toggle-icon").removeClass("bi-chevron-up").addClass("bi-chevron-down");
            }
        })
        // Toggle reply form for comments
        .on('click', '.reply-toggle', function () {
            const comment = $(this).closest('.comment');
            const replyForm = comment.find('.reply-form');

            if (replyForm.is(activeReplyForm)) {
                replyForm.addClass('d-none');
                activeReplyForm = null;
            } else {
                if (activeReplyForm) {
                    activeReplyForm.addClass('d-none');
                }
                replyForm.removeClass('d-none');
                activeReplyForm = replyForm;
            }
        })
        // Toggle child comments
        .on('click', '.toggle-replies', function () {
            const comment = $(this).closest('.comment');
            const childComments = comment.find('.child-comments').first();

            if (childComments.hasClass('d-none')) {
                childComments.removeClass('d-none');
                childComments.find('.child-comments').addClass('d-none');
                $(this).html('<i class="bi bi-dash-circle"></i> Hide Replies');
            } else {
                childComments.addClass('d-none');
                $(this).html('<i class="bi bi-plus-circle"></i> Show Replies');
            }
        })
        // Like button functionality (per post)
        .on('click', '.like-btn', function () {
            var btn = $(this);
            var postId = btn.data("post-id");
            var likeCountSpan = btn.find(".like-count");

            $.ajax({
                url: btn.data("like-url"), // Get URL from data attribute
                type: 'POST',
                data: {
                    postId: postId,
                    userId: btn.data("user-id"), // Get from data attribute
                    __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
                },
                success: function (response) {
                    if (response.success) {
                        likeCountSpan.text(response.likeCount);

                        if (response.liked) {
                            btn.removeClass("btn-outline-success").addClass("btn-success");
                            btn.data("liked", "true");
                        } else {
                            btn.removeClass("btn-success").addClass("btn-outline-success");
                            btn.data("liked", "false");
                        }
                    } else {
                        console.error(response.message || "Something went wrong.");
                    }
                },
                error: function () {
                    console.error("Error occurred while liking the post.");
                }
            });
        })
        // Like comment functionality
        .on('click', '.like-comment-btn', function () {
            var btn = $(this);
            var commentId = btn.data("comment-id");
            var likeCountSpan = btn.find(".like-count");

            $.ajax({
                url: btn.data("like-url"), // Get URL from data attribute
                type: 'POST',
                data: {
                    commentId: commentId,
                    userId: btn.data("user-id"), // Get from data attribute
                    __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
                },
                success: function (response) {
                    if (response.success) {
                        likeCountSpan.text(response.likeCount);

                        if (response.liked) {
                            btn.removeClass("btn-outline-primary").addClass("btn-primary");
                            btn.data("liked", "true");
                        } else {
                            btn.removeClass("btn-primary").addClass("btn-outline-primary");
                            btn.data("liked", "false");
                        }
                    } else {
                        console.error(response.message || "Something went wrong.");
                    }
                },
                error: function () {
                    console.error("Error occurred while liking the comment.");
                }
            });
        });
});