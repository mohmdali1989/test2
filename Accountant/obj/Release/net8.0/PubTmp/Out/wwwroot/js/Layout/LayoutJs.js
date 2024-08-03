
'use strict';

const linkDrops = document.querySelectorAll('.LinkDropMenuTop'); // Select all LinkDrops
 //وخليتو عشان اذا حبيت ارجعو ما اتغلبLinkDropSidebar هاض  الكود ملغي بدلتو في 
linkDrops.forEach(linkDrop => {
    linkDrop.addEventListener('click', (e) => {
        e.preventDefault();
        e.stopPropagation();

        const menuId = linkDrop.getAttribute('data-menuTop');
        const dropdownMenu = document.getElementById(menuId);

        dropdownMenu.classList.toggle('showTop');
        linkDrop.setAttribute('aria-expanded', dropdownMenu.classList.contains('showTop'));

        // Close other open dropdowns
        document.querySelectorAll('.dropDownTop').forEach(otherMenu => {
            if (otherMenu !== dropdownMenu && otherMenu.classList.contains('showTop')) {
                otherMenu.classList.remove('showTop');
                otherMenu.previousElementSibling.setAttribute('aria-expanded', false);
            }
        });
    });
});

document.body.addEventListener('click', (e) => {
    document.querySelectorAll('.dropDownTop').forEach(dropdownMenu => {
        if (!dropdownMenu.contains(e.target)) {
            dropdownMenu.classList.remove('showTop');
            dropdownMenu.previousElementSibling.setAttribute('aria-expanded', false);
        }
    });
});

//====================================================================
const linkDrops1 = document.querySelectorAll('.LinkDropSidebar'); // Select all LinkDrops

linkDrops1.forEach(linkDrop => {
    linkDrop.addEventListener('click', (e) => {
        e.preventDefault();
        e.stopPropagation();

        const menuId = linkDrop.getAttribute('data-menu-Sidebar');
        const dropdownMenu = document.getElementById(menuId);

        dropdownMenu.classList.toggle('show-Sidebar');
        linkDrop.setAttribute('aria-expanded', dropdownMenu.classList.contains('show-Sidebar'));

        // Close other open dropdowns
        document.querySelectorAll('.dropDownSidebar').forEach(otherMenu => {
            if (otherMenu !== dropdownMenu && otherMenu.classList.contains('show-Sidebar')) {
                otherMenu.classList.remove('show-Sidebar');
                otherMenu.previousElementSibling.setAttribute('aria-expanded', false);
            }
        });
    });
});

document.body.addEventListener('click', (e) => {
    document.querySelectorAll('.dropDownSidebar').forEach(dropdownMenu => {
        if (!dropdownMenu.contains(e.target)) {
            dropdownMenu.classList.remove('show-Sidebar');
            dropdownMenu.previousElementSibling.setAttribute('aria-expanded', false);
        }
    });
});

//====================================================================


let LinkDrop = document.querySelectorAll('.LinkDrop');

LinkDrop.forEach(link => {

    link.addEventListener('click', (e) => {
        e.preventDefault()
        let idValue = link.getAttribute("data-menu");

        document.getElementById(idValue).classList.toggle('show');
    });
})

let ContentDashbord = document.querySelector('.Content-dashbord');
let bar = document.querySelector('.bar');

bar.addEventListener('click', function () {
    ContentDashbord.classList.toggle('f-width');
})





let LinkTab = document.querySelectorAll('.LinkTab');
/* موجود في الصفحه  يجلبها كلها LinkTab من الصفحه كلها يعني كم  LinkTab جلب كل  */

LinkTab.forEach(link => {
    link.addEventListener('click', (e) => {
        e.preventDefault();
        let idTab = link.getAttribute('data-areaTab')
        let nameTabs = document.getElementById(idTab)
        let tabContent = document.querySelectorAll('.tab-content');
        let ActiveLink = document.querySelectorAll('.ActiveLink')
        /* موجود في الصفحه  يجلبها كلها tab-content من الصفحه كلها يعني كم  tab-content جلب كل  */

        for (var i = 0; i < ActiveLink.length; i++) {
            ActiveLink[i].classList.remove('ActiveLink')
            /* i وعند الكود الداخل الفور نقوم بحذف حسب رقم الي اهذناه من  i داخل  tab-content ونعضع رقم  tab-content نقوم بعمل فور لوب ونعدد عدد */
        } for (var i = 0; i < tabContent.length; i++) {
            tabContent[i].classList.remove('active')
            /* i وعند الكود الداخل الفور نقوم بحذف حسب رقم الي اهذناه من  i داخل  tab-content ونعضع رقم  tab-content نقوم بعمل فور لوب ونعدد عدد */
        }
        nameTabs.classList.add('active')
        link.classList.add('ActiveLink')
        /*active بعد الحذف نرجع نضيف */

    });
});


/*Grid & List */
let List = document.querySelector('.List');
let Grid = document.querySelector('.Grid');

let cards = document.querySelectorAll('.cards');
let boxs = document.querySelectorAll('.boxs');
List.addEventListener('click', (e) => {
    e.preventDefault();
    cards.forEach(card => {
        card.classList.remove('d-Grid')
    });
    boxs.forEach(box => {
        box.classList.remove('d-Grid')
    });
})
  
Grid.addEventListener('click', (e) => {
    e.preventDefault();
    cards.forEach(card => {
        card.classList.add('d-Grid')
    });
    boxs.forEach(box => {
        box.classList.add('d-Grid')
    });
})





//هذا الكود هذا عرفنا لكل واحد لزحده

//let body = document.querySelector('body');



//هذا الكود افضل لاكن من الذكاء الصظناعي
//LinkDrop.addEventListener('click', (event) => {
//    event.stopPropagation(); // إلغاء توجيه الحدث click إلى العنصر الأبوي
//    dropDown.classList.toggle('show');
//});

///* إضافة مثبت الحدث للكشف عن النقر خارج الشاشة الصغيرة*/
//body.addEventListener('click', (event) => {
//    if (!dropDown.contains(event.target)) {
//        dropDown.classList.remove('show');
//    }
//});
