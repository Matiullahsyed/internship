const puppeteer = require('puppeteer');
(async () => {
    const browser = await puppeteer.launch({headless: false , slowMo: 120});
    const page = await browser.newPage();
  await page.goto("D:\\Newfolder\\javascript\\Student.html");
  await delay(1000);
  await page.type('#sname', 'hashim');
  await page.type('#semail', 'hashim@gmail.com');
  await page.type('#scontactNumber', '03440554436');
  await page.type('#spassword', 'hashim123');
  await page.type('#sconfirmpassword', 'hashim123');
  await page.click("#btn");
  await page.goto("file:///D:\\Newfolder\\javascript\\studentsList.html");
  await delay(1000);
  await page.click("#edit-0");
  await delay(1000);
  await page.evaluate( () => document.getElementById("sname").value = "")
  await page.evaluate( () => document.getElementById("semail").value = "")
  await page.evaluate( () => document.getElementById("scontactNumber").value = "")
  await page.evaluate( () => document.getElementById("spassword").value = "")
  await page.evaluate( () => document.getElementById("sconfirmpassword").value = "")
  await page.type('#sname', 'JackRojer');
  await page.type('#semail', 'JackRojer@gmail.com');
  await page.type('#scontactNumber', '0562532626');
  await page.type('#spassword', 'sparrow');
  await page.type('#sconfirmpassword', 'sparrow');
  await page.click("#btn");
  await delay(1000);
  await page.click("#delete-0");
  await browser.close();
})();
function delay(time) {
    return new Promise(function(resolve) { 
        setTimeout(resolve, time)
    });
  } 