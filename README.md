# Fdo.Api.Contato.Vistoria

## Overview

This API is the server side of the [Contato Vistoria Itabuna Xamarin Forms App](https://github.com/chr0m1ng/Fdo.Contato.Vistoria).

With this API you can **upload** and **download** the images.

## UI

When started the app will open a new window on your default browser with the **config page** located at `http://localhost:5000/api/config`:

CONFIG_PAGE_IMAGE

Here we can change the base **storage path** of the images.
Also, the **API health** can be checked here, we have a status indicator at the navbar alongside the "Contato Vistoria" brand.

CONFIG_PAGE_BLUE_STATUS_IMAGE
CONFIG_PAGE_RED_STATUS_IMAGE

When the API is down the status indicator will be red, otherwise it will remain blue for a healthy API.

At the base URL you can find the **swagger** documentation of the API, you just need to go to the root url `http://localhost:5000`.

SWAGGER_PAGE_IMAGE
