import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import schedule
import telegram_send

driverPath = r""
userJMBG = ""
userBLK = ""

class MoneyChecker:

    def __init__(self):
        self.driver = None

    def checkForMoney(self):
        self.driver = webdriver.Chrome(driverPath)
        self.driver.get("https://idp.trezor.gov.rs/provera")

        wait = WebDriverWait(self.driver, 10)

        wait.until(EC.visibility_of_element_located((By.CLASS_NAME, "v-text-field__slot")))

        jmbg = self.driver.find_element(By.NAME, "registerAccount.uniqueIdentificationNumber")
        blk = self.driver.find_element(By.NAME, "registerAccount.identificationNumber")
        button = self.driver.find_elements(By.CSS_SELECTOR, "button")[1]

        jmbg.send_keys(userJMBG)
        blk.send_keys(userBLK)
        button.click()

        wait.until(EC.visibility_of_element_located((By.CLASS_NAME, "v-stepper__step__step")))

        if str(self.driver.find_elements(By.CLASS_NAME, "v-stepper__step__step")[-1].get_attribute('innerText')) == "5":
            print("No money")
            self.driver.quit()
            telegram_send.send(messages=["No Money"])
        else:
            print("Money!")
            self.driver.quit()
            schedule.clear()
            telegram_send.send(messages=["Got The Money!"])

    def check(self):
        schedule.every(1).hour.do(self.checkForMoney)

        self.checkForMoney()

        while True:
            schedule.run_pending()
            time.sleep(1)


checker = MoneyChecker()
checker.check()
