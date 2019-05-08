$(document).ready(function () {
    
    $('#table').DataTable({
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8,
        fixedColumns: false,
        lengthChange: false,
        Info: true,
        language: {
            zeroRecords: "No registros disponibles"
        }
    });



//    var userFilter, statusFilter, milestoneFilter, priorityFilter, tagsFilter;

//    function updateFilters() {
//        $('.task-list-row').hide().filter(function () {
//            var
//                self = $(this),
//                result = true; // not guilty until proven guilty

//            if (userFilter && (userFilter != 'None')) {
//                result = result && userFilter === self.data('assigned-user');
//            }
//            if (statusFilter && (statusFilter != 'Any')) {
//                result = result && statusFilter === self.data('status');
//            }
//            if (milestoneFilter && (milestoneFilter != 'None')) {
//                result = result && milestoneFilter === self.data('milestone');
//            }
//            if (priorityFilter && (priorityFilter != 'None')) {
//                result = result && priorityFilter === self.data('priority');
//            }
//            if (tagsFilter && (tagsFilter != 'None')) {
//                result = result && tagsFilter === self.data('tags');
//            }

//            return result;
//        }).show();
//    }

//    // Assigned User Dropdown Filter
//    $('#assigned-user-filter').on('change', function () {
//        userFilter = this.value;
//        updateFilters();
//    });

//    // Task Status Dropdown Filter
//    $('#status-filter').on('change', function () {
//        statusFilter = this.value;
//        updateFilters();
//    });

//    // Task Milestone Dropdown Filter
//    $('#milestone-filter').on('change', function () {
//        milestoneFilter = this.value;
//        updateFilters();
//    });

//    // Task Priority Dropdown Filter
//    $('#priority-filter').on('change', function () {
//        priorityFilter = this.value;
//        updateFilters();
//    });

//    // Task Tags Dropdown Filter
//    $('#tags-filter').on('change', function () {
//        tagsFilter = this.value;
//        updateFilters();
//    });

///*
//future use for a text input filter
//$('#search').on('click', function() {
//    $('.box').hide().filter(function() {
//        return $(this).data('order-number') == $('#search-criteria').val().trim();
//    }).show();
//});*/
     
//});

