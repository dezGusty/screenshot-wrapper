#pragma once

#ifndef SCREENSHOT_EXP
#define SCREENSHOTWRAPPER_API __declspec(dllexport)
#else
#define SCREENSHOTWRAPPER_API __declspec(dllimport)
#endif // !SCREENSHOT_EXP